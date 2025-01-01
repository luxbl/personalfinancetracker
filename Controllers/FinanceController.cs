using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using personalfinancetracker.Data;
using personalfinancetracker.Models;

[ApiController]
[Route("api/[controller]")]
public class FinanceController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IHubContext<FinanceHub> _hub;

    public FinanceController(AppDbContext context, IHubContext<FinanceHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    [HttpGet("dashboard")]
    public IActionResult GetDashboardData()
    {
        var incomes = _context.Incomes.ToList();
        var expenses = _context.Expenses.ToList();
        return Ok(new { incomes, expenses });
    }

    [HttpPost("add-income")]
    public async Task<IActionResult> AddIncome([FromBody] Income income)
    {
        _context.Incomes.Add(income);
        await _context.SaveChangesAsync();
        await _hub.Clients.All.SendAsync("ReceiveUpdate", "Income added");
        return Ok(income);
    }

    [HttpPost("add-expense")]
    public async Task<IActionResult> AddExpense([FromBody] Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        await _hub.Clients.All.SendAsync("ReceiveUpdate", "Expense added");
        return Ok(expense);
    }
}
