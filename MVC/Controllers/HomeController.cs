using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult IndexPlaceInArea()
        {
            var areaId = Int32.Parse(Request.Form["areaId"][0]);
            Area area = db.Areas.FirstOrDefault(s => s.Id == areaId);

            var placetypeId = Int32.Parse(Request.Form["placetypeId"][0]);
            var places = db.Places.Include(s => s.PlaceType).Where(s => s.AreaId == areaId && s.PlaceTypeId == placetypeId);

            IndexPlaceInArea vm = new IndexPlaceInArea { Areas = db.Areas.ToList(), Places = places, AreaId = areaId, PlacetypeId = placetypeId };
            return View(vm);
        }

        public IActionResult Events()
        {
            var placeTypes = db.PlaceTypes.ToList();
            var areas = db.Areas.ToList();
            IndexEventsViewModel evm = new IndexEventsViewModel { Areas = areas, PlaceTypes = placeTypes };
            return View(evm);
        }

        public IActionResult Find()
        {
            var areaId = Int32.Parse(Request.Form["AreaId"][0]);
            var placetypeId = Int32.Parse(Request.Form["PlacetypeId"][0]);
            var openNow = Request.Form["OpenNow"][0];
            var startTime = Convert.ToDateTime(Request.Form["StartTime"][0]).TimeOfDay;
            var EndTime = Convert.ToDateTime(Request.Form["EndTime"][0]).TimeOfDay;

            IQueryable<Place> places = db.Places.Include(s => s.PlaceType);
            if (areaId != 0 && placetypeId != 0)
            {
                places = db.Places.Include(s => s.PlaceType).Where(s => s.AreaId == areaId && s.PlaceTypeId == placetypeId);
            }
            else if (areaId == 0 && placetypeId != 0)
            {
                places = db.Places.Include(s => s.PlaceType).Where(s => s.PlaceTypeId == placetypeId);
            }
            else if (areaId !=0 && placetypeId == 0)
            {
                places = db.Places.Include(s => s.PlaceType).Where(s => s.AreaId == areaId);
            }     

            if (openNow == "true")
            {
                var currentTime = DateTime.Now.TimeOfDay;
                var open_places = from p in places
                                  where currentTime >= p.StartWork.TimeOfDay && currentTime < p.EndWork.TimeOfDay
                                  select p;
                places = open_places;
            }
            else
            {
                var open_places = from p in places
                                  where startTime >= p.StartWork.TimeOfDay && EndTime < p.EndWork.TimeOfDay
                                  select p;
                places = open_places;
            }

            IndexPlaceInArea vm = new IndexPlaceInArea { Areas = db.Areas.ToList(), Places = places, AreaId = areaId, PlacetypeId = placetypeId };

            return View("IndexPlaceInArea", vm);
        }
    }
}
