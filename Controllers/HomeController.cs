using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personalfinancetracker.Models;
using personalfinancetracker.Data;
using System.Collections.Generic;
using System.Linq;

namespace personalfinancetracker.Controllers
{
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("UserLoggedIn") != "true")
        {
            return RedirectToAction("Login", "Account");
        }
        //ViewBag.IsUserLoggedIn = HttpContext.Session.GetString("UserLoggedIn") == "true";
        return View();
    }

    public IActionResult Income(string searchString)
    {
        var incomeData =_dbContext.Incomes.ToList();
        if (!string.IsNullOrEmpty(searchString))
        {
            incomeData = incomeData.Where(i =>
            i.Source.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            i.Amount.ToString().Contains(searchString) || 
            i.Id.ToString().Contains(searchString)).ToList();
        }

        ViewData["CurrentFiltered"] = searchString;
        return View(incomeData);
    }
//private  static List<Income> IncomeData = new List<Income>
//{    new Income { Id = 1, Source = "Salary", Amount = 5000, Date = DateTime.Now.AddDays(-2) },
//    new Income { Id = 2, Source = "Freelancing", Amount = 1200, Date = DateTime.Now.AddDays(-4) },
 //   new Income {Id = 3, Source = "Stock market", Amount = 1800, Date = DateTime.Now.AddDays(-6) },
   // new Income {Id = 4, Source = "Dividend", Amount = 245, Date = DateTime.Now.AddDays(-8) },
   // new Income { Id = 5, Source = "Bonus", Amount = 750, Date = DateTime.Now.AddDays(-10) }
//};


//public IActionResult Income(string searchString)
//{  
    
  //  IEnumerable<Income> filteredIncomeData = IncomeData;
 //if (!string.IsNullOrEmpty(searchString))
 //{
  //  filteredIncomeData = IncomeData.Where(i => i.Source.Contains(searchString, StringComparison.OrdinalIgnoreCase)
 //  || i.Amount.ToString().Contains(searchString) || i.Id.ToString().Contains(searchString));
 //}
 //   ViewData["CurrentFiltered"] = searchString;
  //  return View(filteredIncomeData);
//}

public IActionResult EditIncome(int id)
{
    //var income = IncomeData.FirstOrDefault(x => x.Id == id);
    var income = _dbContext.Incomes.FirstOrDefault(x => x.Id == id);
    if (income == null) return NotFound();
    return View(income);
}

[HttpPost]
//public IActionResult EditIncome(Income updatedIncome)
//{
   // var income = IncomeData.FirstOrDefault(x => x.Id == updatedIncome.Id);
   // if (income != null)
   // {
 //       income.Source = updatedIncome.Source;
  //      income.Amount = updatedIncome.Amount;
  //      income.Date = updatedIncome.Date;
  //  }
   // return RedirectToAction("Income");
//}
public IActionResult EditIncome(Income updatedIncome)
        {
            if (ModelState.IsValid)
            {
                var income = _dbContext.Incomes.FirstOrDefault(x => x.Id == updatedIncome.Id);
                if (income != null)
                {
                    income.Source = updatedIncome.Source;
                    income.Amount = updatedIncome.Amount;
                    income.Date = updatedIncome.Date;
                    _dbContext.SaveChanges();
                }
                return RedirectToAction("Income");
            }
            return View(updatedIncome);
        }

public IActionResult DeleteIncome(int id)
{
    var income = _dbContext.Incomes.FirstOrDefault(x => x.Id == id);
    if (income != null)
    {
        //IncomeData.Remove(income);
        _dbContext.Incomes.Remove(income);
        _dbContext.SaveChanges();
    }
    return RedirectToAction("Income");
}

public IActionResult AddIncome()
{
    return View(new Income());
}

[HttpPost]
//public IActionResult AddIncome(Income newIncome)
//{
//    newIncome.Id = IncomeData.Max(x => x.Id) + 1; // Generate a new ID
 //   IncomeData.Add(newIncome);
  //  return RedirectToAction("Income");
//}
public IActionResult AddIncome(Income newIncome)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Incomes.Add(newIncome);
                _dbContext.SaveChanges();
                return RedirectToAction("Income");
            }
            return View(newIncome);
        }

        public IActionResult Expense()
        {
            var expenseData = _dbContext.Expenses.ToList();
            return View(expenseData);
        }

    /*public IActionResult Expense()
    {

        var expenseData = new List<Expense>
        {
          new Expense { Id = 1, Source = "Grocery", Amount = 350, Date = DateTime.Now.AddDays(-2) },
          new Expense { Id = 2, Source = "Gas and others", Amount = 500, Date = DateTime.Now.AddDays(-4) },
          new Expense { Id = 3, Source = "Utility Bills", Amount = 275, Date = DateTime.Now.AddDays(-6) }
        };

        return View(expenseData);
    }
    */
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
