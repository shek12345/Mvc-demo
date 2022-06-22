using Microsoft.AspNetCore.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class BookController : Controller
    {
        public IActionResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBook(Book book)
        {
            return View();
        }
    }
}
