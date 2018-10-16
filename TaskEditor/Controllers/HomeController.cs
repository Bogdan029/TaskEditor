using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskEditor.Models;

namespace TaskEditor.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();

        [Authorize]
        public ActionResult Index()
        {
            //string result = "No";
            //if (User.Identity.IsAuthenticated)
            //{
            //    result = User.Identity.Name;
            //}

            ViewBag.Message = User.Identity.Name;
            var tasks = db.Tasks;

            SelectList authors = new SelectList(db.Tasks, "Name", "Name");
            ViewBag.Author = authors;

            return View(tasks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult Edit(Task book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task t = db.Tasks.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            db.Tasks.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public RedirectToRouteResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToRoute(new { controller = "Account", action = "Login" });
        }
    }
}