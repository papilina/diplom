using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        MainContext db;

        public HomeController(MainContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.Areas = new SelectList(db.Areas, "Id", "Name");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public  IActionResult DetailArea(int Id)
        {
            Area area = db.Areas.FirstOrDefault(s => s.Id == Id);
            IEnumerable<PlaceType> placeTypes = db.PlaceTypes.ToList();

            DetailAreaModel dam = new DetailAreaModel { Area = area, PlaceTypes = placeTypes };
            return View(dam);
        }

        [HttpPost]
        public IActionResult IndexPlaceInArea()
        {
            var form = Request.Form;
            return View();
        }
    }
}
