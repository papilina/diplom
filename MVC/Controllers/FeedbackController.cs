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
    public class FeedbackController : Controller
    {
        MainContext db;

        public FeedbackController(MainContext context)
        {
            db = context;
        }

        // GET: Feedback
        public ActionResult Index()
        {
            return View(db.Feedbacks.Include(x => x.User).Include(x => x.Place));
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Feedback feedback = db.Feedbacks.Include(x => x.User).Include(x => x.Place).FirstOrDefault(s => s.Id == id);
                return View(feedback);
            }
            return NotFound();    
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            ViewBag.Users = new SelectList(db.Users , "Id", "Name");
            ViewBag.Places = new SelectList(db.Places, "Id", "Name");
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            try
            {
                feedback.User = db.Users.FirstOrDefault(s => Int32.Parse(s.Id) == feedback.UserId);
                feedback.Place = db.Places.FirstOrDefault(s => s.Id == feedback.PlaceId);
                db.Feedbacks.Add(feedback);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Feedback feedback = db.Feedbacks.FirstOrDefault(s => s.Id == id);
                SelectList users = new SelectList(db.Users, "Id", "Name", feedback.UserId);
                ViewBag.Users = users;
                SelectList places = new SelectList(db.Places, "Id", "Name", feedback.PlaceId);
                ViewBag.Places = places;
                return View(feedback);
            }
            return NotFound();
        }

        // POST: Feedback/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Feedback feedback)
        {
            try
            {
                db.Feedbacks.Update(feedback);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Feedback feedback = db.Feedbacks.Include(x => x.User).Include(x => x.Place).FirstOrDefault(s => s.Id == id);
                return View(feedback);
            }
            return NotFound();
        }

        // POST: Feedback/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Feedback feedback)
        {
            try
            {
                db.Feedbacks.Remove(feedback);
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