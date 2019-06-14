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
        public ActionResult BusSeat(int id)
        {
            // KoltukNo'larinin hepsini cek  ve temp listeye ata
            
             var _seats = Database.Session.QueryOver<SoldTicket>()
                .Where(u => u.RouteID == id)
                .Select(c => c.KoltukNo)
                .List<int>();
                
            /*var _seats = Database.Session.Query<SoldTicket>()
                .Where(u => u.RouteID == id)
                .ToList();

            foreach (var anan in _seats)
            {
                anan.KoltukNo
            }*/

            /*
            List<int> _seats = new List<int>();

            _seats = Database.Session.CreateQuery("Select KoltukNo from sold_ticket st WHERE st.RouteID = :id")
                .SetParameter("id", id)
                .UniqueResult();
            */

            return View("BusSeat", new BusTicket()
            {
                Seats = _seats
            });
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
        public ActionResult BusSeat(BusTicket form, int id) // How come id parameter does work? when it didnt work for admin form ActionResult's
        {
            if (!ModelState.IsValid)
                return View(form);

            SoldTicket ticket;

            var _bus = Database.Session.Load<BusInfo>(id);
            if (_bus.KoltukSayisi == 0)
            {
                ModelState.AddModelError("KoltukSayisi", "Tum koltuklar dolmustur!");
            }

            _bus.KoltukSayisi -= 1;
            
            ticket = new SoldTicket()
            {
                RouteID = id,
                YolcuAd = form.YolcuAd,
                YolcuSoyad = form.YolcuSoyad,
                Telefon = form.Telefon,
                Email = form.Email,
                KoltukNo = form.KoltukNo,
                KimlikNo = form.KimlikNo
            };

            form.Bus_ID = id;
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