using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AreaController : Controller
    {
        MainContext db;
        
        public AreaController(MainContext context)
        {
            db = context;
        }

        // GET: Area
        public ActionResult Index()
        {
            return View(db.Areas.ToList());
        }

        // GET: Area/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Area area = db.Areas.FirstOrDefault(s => s.Id == id);
                if (area != null)
                    return View(area);
            }
            return NotFound();           
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Area area)
        {
            try
            {
                db.Areas.Add(area);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Area area = db.Areas.FirstOrDefault(s => s.Id == id);
                return View(area);
            }
            return NotFound();
        }

        // POST: Area/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Area area)
        {
            try
            {
                db.Areas.Update(area);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Area area = db.Areas.FirstOrDefault(s => s.Id == id);
                return View(area);
            }
            return NotFound();
        }

        // POST: Area/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Area area)
        {
            try
            {
                db.Areas.Remove(area);
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