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

        public ActionResult Sold(BusTicket form)
        {
            // var soldTicket = Database.Session.Load<SoldTicket>(bus_id);

            //if (soldTicket  == null) 
            //  return HttpNotFound();

            if (form == null)
                return HttpNotFound();

            return View(form);
        }

        [HttpPost]
        public ActionResult BusSeat(BusTicket form, int bus_id)
        {
            if (!ModelState.IsValid)
                return View(form);

            SoldTicket ticket;

            var _bus = Database.Session.Load<BusInfo>(bus_id);
            _bus.KoltukSayisi -= 1;
            
            ticket = new SoldTicket()
            {
                RouteID = bus_id,
                YolcuAd = form.YolcuAd,
                YolcuSoyad = form.YolcuSoyad,
                Telefon = form.Telefon,
                Email = form.Email,
                KoltukNo = form.KoltukNo,
            };

            form.Bus_ID = bus_id;
            form.nereden = _bus.KalkisDest;
            form.nereye = _bus.VarisDest;
            form.binisSaat = _bus.KalkisTime;
            form.inisSaat = _bus.VarisTime;
            form.tarih = _bus.KalkisDate;

            Database.Session.SaveOrUpdate(ticket);
            Database.Session.Flush();

            Database.Session.SaveOrUpdate(_bus);
            Database.Session.Flush();

            return View("Sold", form);
        }
    }
}