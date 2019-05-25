using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.Areas.Admin.ViewModels;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(AuthLogin form)
        {

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AuthLogin form)
        {
            /* if (Database.Session.Query<User>().Any(u => u.Username == form.Username))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            } */

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var user = new User()
            {
                Username = form.Username,
                Password = form.Password
            };

            Database.Session.Save(user);

            return RedirectToAction("Index");
        }
    }
}