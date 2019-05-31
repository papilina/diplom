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
    public class VisitController : Controller
    {
        MainContext db;

        public VisitController(MainContext context)
        {
            db = context;
        }

        // GET: Visit
        public ActionResult Index()
        {
            return View(db.Visits.Include(x => x.User).Include(x => x.Place));
        }

        // GET: Visit/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Visit visit = db.Visits.Include(x => x.User).Include(x => x.Place).FirstOrDefault(s => s.Id == id);
                return View(visit);
            }
            return NotFound();
        }

        // GET: Visit/Create
        public ActionResult Create()
        {
            ViewBag.Users = new SelectList(db.Users, "Id", "Name");
            ViewBag.Places = new SelectList(db.Places, "Id", "Name");
            return View();
        }

        // POST: Visit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visit visit)
        {
            try
            {
                db.Visits.Add(visit);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Visit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Visit visit = db.Visits.FirstOrDefault(s => s.Id == id);
                SelectList users = new SelectList(db.Users, "Id", "Name", visit.UserId);
                ViewBag.Users = users;
                SelectList places = new SelectList(db.Places, "Id", "Name", visit.PlaceId);
                ViewBag.Places = places;
                return View(visit);
            }
            return NotFound();
        }

        // POST: Visit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Visit visit)
        {
            try
            {
                db.Visits.Update(visit);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Visit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Visit visit = db.Visits.Include(x => x.User).Include(x => x.Place).FirstOrDefault(s => s.Id == id);
                return View(visit);
            }
            return NotFound();
        }

        // POST: Visit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Visit visit)
        {
            try
            {
                db.Visits.Remove(visit);
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