using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.ViewModels;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Index(BusQuery form)
        {
            var _bus = Database.Session.Query<BusInfo>()
                .Where(u => u.KalkisDest == form.KalkisDest)
                .Where(u => u.VarisDest == form.VarisDest)
                .Where(u => u.KalkisDate == form.KalkisDate)
                .ToList();

            if (_bus.Count == 0)
            {
                // AddModelError'e atadigin ilk parametre(key) hata cikartabilir.
                ModelState.AddModelError("KalkisDest", "Seçtiğiniz 2 şehir arası otobüs yolculuğu bulunmamaktadır.");
                return View(form);
            }

            return View("Routes", new BusSearch
            {
                BusesToSearch = _bus
            });
        }
    }
}