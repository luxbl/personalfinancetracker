using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personalfinancetracker.Models;

namespace personalfinancetracker.Controllers
{
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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

    //public IActionResult Income()
    //{
   //     return View();
    // }
//   public IActionResult Income()
//{
//    var incomeData = new List<Income>
//    {
//        new Income { Id = 1, Source = "Salary", Amount = 5000, Date = DateTime.Now.AddDays(-2) },
//        new Income { Id = 2, Source = "Freelancing", Amount = 1200, Date = DateTime.Now.AddDays(-4) },
//        new Income {Id = 3, Source = "Stock market", Amount = 1800, Date = DateTime.Now.AddDays(-6) }
//    };
//
//    return View(incomeData);
//}

//new changes
private  static List<Income> IncomeData = new List<Income>
{
    new Income { Id = 1, Source = "Salary", Amount = 5000, Date = DateTime.Now.AddDays(-2) },
    new Income { Id = 2, Source = "Freelancing", Amount = 1200, Date = DateTime.Now.AddDays(-4) },
    new Income {Id = 3, Source = "Stock market", Amount = 1800, Date = DateTime.Now.AddDays(-6) }
};


public IActionResult Income()
{  
    return View(IncomeData);
}

public IActionResult EditIncome(int id)
{
    var income = IncomeData.FirstOrDefault(x => x.Id == id);
    if (income == null) return NotFound();
    return View(income);
}

[HttpPost]
public IActionResult EditIncome(Income updatedIncome)
{
    var income = IncomeData.FirstOrDefault(x => x.Id == updatedIncome.Id);
    if (income != null)
    {
        income.Source = updatedIncome.Source;
        income.Amount = updatedIncome.Amount;
        income.Date = updatedIncome.Date;
    }
    return RedirectToAction("Income");
}

public IActionResult DeleteIncome(int id)
{
    var income = IncomeData.FirstOrDefault(x => x.Id == id);
    if (income != null)
    {
        IncomeData.Remove(income);
    }
    return RedirectToAction("Income");
}

public IActionResult AddIncome()
{
    return View(new Income());
}

[HttpPost]
public IActionResult AddIncome(Income newIncome)
{
    newIncome.Id = IncomeData.Max(x => x.Id) + 1; // Generate a new ID
    IncomeData.Add(newIncome);
    return RedirectToAction("Income");
}



    //public IActionResult Expense()
    //{
     //   return View();
   // }

    public IActionResult Expense()
    {
        var expenseData = new List<Expense>
        {
          new Expense { Id = 1, Source = "Grocery", Amount = 350, Date = DateTime.Now.AddDays(-2) },
          new Expense { Id = 2, Source = "Gas and others", Amount = 500, Date = DateTime.Now.AddDays(-4) },
          new Expense { Id = 3, Source = "Utility Bills", Amount = 275, Date = DateTime.Now.AddDays(-6) }
        };

        return View(expenseData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
