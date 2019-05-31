using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtobusBiletiUygulamasi.Areas.Admin.ViewModels;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.Username);

            if (user == null)
                Models.User.FakeHash();

            if (user == null || !user.CheckPassword(form.Password)) { 
                ModelState.AddModelError("Username", "Username or password is incorrect");
                return View(form);
            }

            FormsAuthentication.SetAuthCookie(form.Username, true);
            return RedirectToAction("Index", "Bus");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AuthLogin form)
        {
            if (Database.Session.Query<User>().Any(u => u.Username == form.Username)) // Sonradan yorumdan kaldirdim, test et calisiyor mu veya bozuyor mu
            {
                ModelState.AddModelError("Username", "Username must be unique");
            } 

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var user = new User()
            {
                Username = form.Username,
                Password = form.Password
            };

            user.setPassword(user.Password);

            Database.Session.Save(user);

            return RedirectToAction("Index", "Bus");
        }
    }
}