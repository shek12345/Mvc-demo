using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvcproject.Models;
using System;
//Iactionresult is a return type=show html output

namespace Mvcproject.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeDAL context = new EmployeeDAL();
        public IActionResult List()

        {
            ViewBag.EmployeeList = context.GetAllEmployees();
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
            Employee e = new Employee();
            e.Id = Convert.ToInt32(form["Id"]);
            e.Name = form["Name"];
            e.Salary = Convert.ToDecimal(form["Salary"]);
            int res = context.Save(e);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)

        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary ;
            ViewBag.Id = emp.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)

        {
            Employee e = new Employee();
            e.Id = Convert.ToInt32(form["Id"]);
            e.Name = form["Name"];
            e.Salary = Convert.ToDecimal(form["Salary"]);
            int res = context.Update(e);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)

        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary;
            ViewBag.Id = emp.Id;
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
    
