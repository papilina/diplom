using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class PlaceController : Controller
    {
        MainContext db;

        public PlaceController(MainContext context)
        {
            db = context;
        }

        // GET: Place
        public ActionResult Index()
        {
            return View(db.Places.Include(x => x.Area).Include(x => x.PlaceType));
        }

        // GET: Place/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Place place = db.Places.Include(x => x.Area).Include(x => x.PlaceType).FirstOrDefault(s => s.Id == id);
                return View(place);
            }
            return NotFound();
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            ViewBag.PlaceTypes = new SelectList(db.PlaceTypes, "Id", "Name");
            ViewBag.Areas = new SelectList(db.Areas, "Id", "Name");
            return View();
        }

        // POST: Place/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Place place)
        {
            try
            {
                place.PlaceType = db.PlaceTypes.FirstOrDefault(s => s.Id == place.PlaceTypeId);
                place.Area = db.Areas.FirstOrDefault(s => s.Id == place.AreaId);
                db.Places.Add(place);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Place place = db.Places.FirstOrDefault(s => s.Id == id);
                SelectList placetypes = new SelectList(db.PlaceTypes, "Id", "Name", place.PlaceTypeId);
                ViewBag.PlaceTypes = placetypes;
                SelectList areas = new SelectList(db.Areas, "Id", "Name", place.AreaId);
                ViewBag.Areas = areas;
                return View(place);
            }
            return NotFound();
        }

        // POST: Place/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Place place)
        {
            try
            {
                db.Places.Update(place);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Place/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Place place = db.Places.Include(x => x.Area).Include(x => x.PlaceType).FirstOrDefault(s => s.Id == id);
                return View(place);
            }
            return NotFound();
        }

        // POST: Place/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Place place)
        {
            try
            {
                db.Places.Remove(place);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}