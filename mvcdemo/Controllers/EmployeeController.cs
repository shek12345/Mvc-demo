using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcdemo.Models;
using System.Collections.Generic;

    

namespace mvcdemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Employeelist()
            
        {
            List<Employee> employeelist = new List<Employee>()
            {
                new Employee { Id = 1, Name = "shekhar", MobileNo = 9850396173, salary = 858888 },
                 new Employee { Id = 2, Name = "akash", MobileNo = 8850396173, salary = 888888 },
                  new Employee { Id = 3, Name = "amit", MobileNo = 7850396173, salary = 887888 },
                   new Employee { Id = 4, Name = "amol", MobileNo = 9850395173, salary = 888878 },
                    new Employee { Id = 5, Name = "ajay", MobileNo = 8750396173, salary = 887788 },
                     new Employee { Id = 6, Name = "suraj", MobileNo = 9880396173, salary = 778888 },

            };
            ViewBag.Employeelist = employeelist;
            return View();
           
        }
        [HttpGet]
        public IActionResult NewEmployee()
        {
            List<string> Options = new List<string>();
            Options.Add("Choose an Option");
            Options.Add("java developer");
            Options.Add("dot net");
            ViewData["Options"] = new SelectList(Options);
            return View();
            
        }
        [HttpPost]
        public IActionResult NewEmployee(IFormCollection fc)
        {
            ViewBag.Id = fc["Id"];
            ViewBag.name = fc["name"];
            ViewBag.phone = fc["phone"];
            ViewBag.salary = fc["salary"];


            ViewBag.options = fc["Options"];
            return View("EmployeeDetails");
        }
    }
}
