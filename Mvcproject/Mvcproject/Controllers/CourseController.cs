using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvcproject.Models;
using System;

namespace Mvcproject.Controllers
{
    public class CourseController : Controller
    {
   
        CourseDAL context = new CourseDAL();
        public IActionResult List()

        {
            ViewBag.CourseList = context.GetAllCourses();
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
            Course c = new Course();
            c.Id = Convert.ToInt32(form["Id"]);
            c.Name = form["Name"];
            c.Fees = Convert.ToDecimal(form["Fees"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)

        {
            Course cour = context.GetCourseById(id);
            ViewBag.Name = cour.Name;
            ViewBag.Fees = cour.Fees;
            ViewBag.Id = cour.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)

        {
            Course c = new Course();
            c.Id = Convert.ToInt32(form["Id"]);
            c.Name = form["Name"];
            c.Fees = Convert.ToDecimal(form["Fees"]);
            int res = context.Update(c);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)

        {
            Course cour = context.GetCourseById(id);
            ViewBag.Name = cour.Name;
            ViewBag.Fees = cour.Fees;
            ViewBag.Id = cour.Id;
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

