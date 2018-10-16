using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskEditor.Models;

namespace TaskEditor.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (DBContext db = new DBContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login && u.Password == model.Password);
                }


                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ViewBag.Register = "Incorrect login or password";
                }
            }
            return View(model);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    User user = null;
                    using (DBContext db = new DBContext())
                    {
                        user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                    }

                    if (user == null)
                    {
                        using (DBContext db = new DBContext())
                        {
                            db.Users.Add(new User { Email = model.Email, Password = model.Password, Name = model.Name, Surname = model.Surname });
                            db.SaveChanges();

                            user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                        }

                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {

                        ViewBag.Message = "User already exist";
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Register");

            }
        }


    }
}