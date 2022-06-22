using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mvcdemo.Models;



namespace mvcdemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Productlist()
        {
            List<Product> productlist = new List<Product>() 
            {
                new Product { Id = 1, Name = "Laptop", Compony = "dell", price = 888888 },
                new Product { Id = 2, Name = "Laptop", Compony = "hp", price = 88888 },
                new Product { Id = 3, Name = "Laptop", Compony = "lenovo", price = 8888 },
               new Product { Id = 4, Name = "Laptop", Compony = "dell", price = 8888 },


            };
            ViewBag.Productlist = productlist;
            return View();
        }
    }
}
