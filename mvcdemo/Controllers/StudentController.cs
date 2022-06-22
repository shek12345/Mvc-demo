using Microsoft.AspNetCore.Mvc;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            return View();
        }
    }
}
