using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PlaceTypeController : Controller
    {
        MainContext db;

        public PlaceTypeController(MainContext context)
        {
            db = context;
        }

        // GET: PlaceType
        public ActionResult Index()
        {
            return View(db.PlaceTypes.ToList());
        }

        // GET: PlaceType/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null) {
                PlaceType placetype = db.PlaceTypes.FirstOrDefault(s => s.Id == id);
                return View(placetype);
            }
            return NotFound();
        }

        // GET: PlaceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaceType placetype)
        {
            try
            {
                db.PlaceTypes.Add(placetype);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaceType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                PlaceType placetype = db.PlaceTypes.FirstOrDefault(s => s.Id == id);
                return View(placetype);
            }
            return NotFound();
        }

        // POST: PlaceType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaceType placeType)
        {
            try
            {
                db.PlaceTypes.Update(placeType);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaceType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                PlaceType placetype = db.PlaceTypes.FirstOrDefault(s => s.Id == id);
                return View(placetype);
            }
            return NotFound();
        }

        // POST: PlaceType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PlaceType placeType)
        {
            try
            {
                db.PlaceTypes.Remove(placeType);
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