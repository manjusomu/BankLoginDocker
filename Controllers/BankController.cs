using Microsoft.AspNetCore.Mvc;
using WebAppBank.Models;

namespace WebAppBank.Controllers
{
    public class BankController : Controller
    {
      
        public IActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (IsValidUser(model.Username, model.Password))
                {
                    // Redirect to the dashboard page
                    return RedirectToAction("Dashboard", new { username = model.Username });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }
           
            return View(model);
        }

       
        public IActionResult Dashboard(string username)
        {
           
            DashboardViewModel viewModel = new DashboardViewModel
            {
                Username = username,
                
                AccountBalance = (double)GetAccountBalance(username)
            };
            return View(viewModel);
        }

        private bool IsValidUser(string username, string password)
        {
           
            return true;
        }

        private decimal GetAccountBalance(string username)
        {
            
            return 1000.00m;
        }
        [HttpPost]
        public IActionResult Logout()
        {
            // return RedirectToAction("Login");
            return View();
        }

    }
}

