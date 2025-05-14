using Microsoft.AspNetCore.Mvc;
using st10384480AgriConnect.Models;
using st10384480AgriConnect.Data;
using System.Collections.Generic;
using System.Linq;

namespace st10384480AgriConnect.Controllers
{
    public class FarmerController : Controller
    {
        public static List<Product> Products = new List<Product>();

        public IActionResult FarmerDashboard(string email)
        {
            ViewBag.Email = email;
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
            product.Role = "Farmer";
            ProductStorage.Products.Add(product);
            return RedirectToAction("MyProducts", new { email = email });
        }

        public IActionResult MyProducts(string email)
        {
            var myProducts = Products.Where(p => p.OwnerEmail == email).ToList();
            ViewBag.Email = email;
            return View(myProducts);
        }
    }
}