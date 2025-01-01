using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Simple authentication (replace with proper logic)
        if (username == "admin" && password == "password")
        {
            // Save session or authentication token
            HttpContext.Session.SetString("UserLoggedIn", "true");
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid username or password";
    
        return View();
    }

    public IActionResult Logout()
    {
        // Clear session
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    
}
