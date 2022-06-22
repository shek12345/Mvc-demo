using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace mvcdemo.Controllers
{
    
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult PersonalDetails()
        {
            List<string> Options = new List<string>();
            Options.Add("Choose an Option");
            Options.Add("Yes");
            Options.Add("No");
            ViewData["Options"] = new SelectList(Options);
            return View();
        }
        [HttpPost]
        public IActionResult PersonalDetails(IFormCollection fc,ICollection<string>hobbies)
            {
            ViewBag.firstname = fc["firstname"];
            ViewBag.lastname = fc["lastname"];
            ViewBag.phone= fc["phone"];
            ViewBag.gender = fc["Gender"];
            ViewBag.hobbies = hobbies;
            ViewBag.options = fc["Options"];
            return View("Details");
        }
    }
}
