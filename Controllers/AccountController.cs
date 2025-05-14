using Microsoft.AspNetCore.Mvc;
using st10384480AgriConnect.Models;
using System.Collections.Generic;
using System.Linq;

namespace st10384480AgriConnect.Controllers
{
    public class AccountController : Controller
    {
        public static List<User> Users = new List<User>();

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Error = "User already exists.";
                return View();
            }

            Users.Add(user);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var existing = Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existing == null)
            {
                ViewBag.Error = "Invalid credentials.";
                return View();
            }

            if (existing.Role == "Farmer")
                return RedirectToAction("FarmerDashboard", "Farmer", new { email = existing.Email });

            if (existing.Role == "Employee")
                return RedirectToAction("EmployeeDashboard", "Employee");

            return View();
        }
    }
}