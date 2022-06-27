using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvcproject.Models;
using System;

namespace Mvcproject.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        public IActionResult List()

        {
            ViewBag.ProductList = context.GetAllProducts();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)

        {
            Product p = new Product();
            p.Id = Convert.ToInt32(form["Id"]);
            p.Name = form["Name"];
            p.Price = Convert.ToDecimal(form["Price"]);
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)

        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)

        {
            Product p = new Product();
            p.Id = Convert.ToInt32(form["Id"]);
            p.Name = form["Name"];
            p.Price = Convert.ToDecimal(form["Price"]);
            int res = context.Update(p);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)

        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)

        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
    }
}
