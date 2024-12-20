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
/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

/*public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string username, string password)
    {
        // Replace with proper user authentication logic
        if (IsValidUser(username, password))
        {
            // Create user claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Administrator") // Example role
            };

            // Create claims identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Keep the user logged in across sessions
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30) // Set expiration
            };

            // Sign in the user
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Login failed"; // Avoid detailed error messages
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    private bool IsValidUser(string username, string password)
    {
        // Replace this logic with your user database and hashed password validation
        return username == "admin" && password == "password";
    }
}
*/

