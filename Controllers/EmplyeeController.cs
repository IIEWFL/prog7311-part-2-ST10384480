using Microsoft.AspNetCore.Mvc;
using st10384480AgriConnect.Models;
using st10384480AgriConnect.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace st10384480AgriConnect.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDashboard()
        {
            return View();
        }

        public IActionResult AddProduct(string email)
        {
            ViewBag.Email = email;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, string email)
        {
            product.OwnerEmail = email;
            product.Role = "Employee";
            ProductStorage.Products.Add(product);
            return RedirectToAction("MyProducts", new { email = email });
        }

        public IActionResult MyProducts(string email)
        {
            ViewBag.Email = email;
            var products = ProductStorage.Products
                .Where(p => p.OwnerEmail == email && p.Role == "Employee")
                .ToList();
            return View(products);
        }

        public IActionResult AddFarmer()
        {
            return View();
        }

        public IActionResult FarmerList()
        {
            var farmers = UserStorage.Users.Where(u => u.Role == "Farmer").ToList();
            return View(farmers);
        }

        public IActionResult FilterProducts()
        {
            return View(ProductStorage.Products);
        }
    }
}