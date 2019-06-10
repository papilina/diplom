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
    public class EvaluationController : Controller
    {

        MainContext db;

        public EvaluationController(MainContext context)
        {
            db = context;
        }

        // GET: Evaluation
        public ActionResult Index()
        {
            return View(db.Evaluations.Include(x => x.User).Include(x => x.Place));
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                Evaluation evaluation = db.Evaluations.FirstOrDefault(s => s.Id == id);
                return View(evaluation);
            }
            return NotFound();
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            ViewBag.Users = new SelectList(db.Users, "Id", "Name");
            ViewBag.Places = new SelectList(db.Places, "Id", "Name");
            return View();
        }

        // POST: Evaluation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evaluation evaluation)
        {
            try
            {
                evaluation.User = db.Users.FirstOrDefault(s => Int32.Parse(s.Id) == evaluation.UserId);
                evaluation.Place = db.Places.FirstOrDefault(s => s.Id == evaluation.PlaceId);
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Evaluation evaluation = db.Evaluations.FirstOrDefault(s => s.Id == id);
                SelectList users = new SelectList(db.Users, "Id", "Name", evaluation.UserId);
                ViewBag.Users = users;
                SelectList places = new SelectList(db.Places, "Id", "Name", evaluation.PlaceId);
                ViewBag.Places = places;
                return View(evaluation);
            }
            return NotFound();
        }

        // POST: Evaluation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Evaluation evaluation)
        {
            try
            {
                db.Evaluations.Update(evaluation);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Evaluation evaluation = db.Evaluations.Include(x => x.User).Include(x => x.Place).FirstOrDefault(s => s.Id == id);
                return View(evaluation);
            }
            return NotFound();
        }

        // POST: Evaluation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Evaluation evaluation)
        {
            try
            {
                db.Evaluations.Remove(evaluation);
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