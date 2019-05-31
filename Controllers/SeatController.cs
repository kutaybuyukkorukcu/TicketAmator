using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.ViewModels;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Controllers
{
    public class SeatController : Controller
    {
        public ActionResult BusSeat()
        {
            return View();
        }

        public ActionResult Sold(int bus_id)
        {
            var soldTicket = Database.Session.Load<SoldTicket>(bus_id);

            if (soldTicket  == null) 
                return HttpNotFound();

            return View(soldTicket);
        }

        [HttpPost]
        public ActionResult BusSeat(BusTicket form, int bus_id)
        {
            if (!ModelState.IsValid)
                return View(form);

            SoldTicket ticket;

            ticket = new SoldTicket()
            {
                BusID = bus_id,
                YolcuAd = form.YolcuAd,
                YolcuSoyad = form.YolcuSoyad,
                Telefon = form.Telefon,
                Email = form.Email,
                KoltukNo = form.KoltukNo
            };

            form.Bus_ID = bus_id;

            Database.Session.SaveOrUpdate(ticket);
            Database.Session.Flush();

            var _bus = Database.Session.Load<BusInfo>(bus_id);

            _bus.KoltukSayisi -= 1;

            Database.Session.SaveOrUpdate(_bus);
            Database.Session.Flush();

            return View("Sold", form);
        }
    }
}