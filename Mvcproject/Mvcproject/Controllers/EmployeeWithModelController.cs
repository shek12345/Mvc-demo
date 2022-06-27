using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvcproject.Models;

namespace Mvcproject.Controllers
{
    public class EmployeeWithModelController : Controller
    {
        EmployeeDAL db = new EmployeeDAL();
        // GET: EmployeeWithModelController
        public ActionResult Index()
        {
            var model = db.GetAllEmployees();
            return View(model);
        }

        // GET: EmployeeWithModelController/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = db .GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                db.Save(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
           Employee emp = db.GetEmployeeById(id);
            return View(emp);
            
        }

        // POST: EmployeeWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                db.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
           Employee emp = db.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
