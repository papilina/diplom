using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        MainContext db;

        public UserController(MainContext context)
        {
            db = context;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                User user = db.Users.FirstOrDefault(s => s.Id == id);
                return View(user);
            }
            return NotFound();
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create() //показывает cтраницу ввода
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)  //отправляет данные
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));  //переход на метод индекс
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)  //показывает стр изменения, ?- может быть, может не быть
        {
            if (id != null)
            {
                User user = db.Users.FirstOrDefault(s => s.Id == id);//возвращает запись юзер, где s.id(модель)=id (котор передали)
                return View(user);
            }
            return NotFound();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user) //отправляет данные
        {
            try
            {
                db.Users.Update(user);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                User user = db.Users.FirstOrDefault(s => s.Id == id);
                return View(user);
            }
            return NotFound();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                db.Users.Remove(user);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();//возвращ шаблон с названием метода. в данном случае Delete
            }
        }
    }
}