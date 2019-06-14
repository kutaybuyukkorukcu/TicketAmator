using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.Areas.Admin.ViewModels;
using OtobusBiletiUygulamasi.Models;
using OtobusBiletiUygulamasi.Infrastructure;

namespace OtobusBiletiUygulamasi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BusController : Controller
    {
        private const int BusPerPage = 5;

        public ActionResult Index(int page = 1)
        {

            var totalBusCount = Database.Session.Query<BusInfo>().Count();

            var currentBusses = Database.Session.Query<BusInfo>()
                .OrderByDescending(p => p.KalkisDest)
                .Skip((page - 1) * BusPerPage)
                .Take(BusPerPage)
                .ToList();

            return View(new BusIndex()
            {
                Buses = new PagedBuses<BusInfo>(currentBusses, totalBusCount, page, BusPerPage)
            });
        }

        public ActionResult New()
        {
            var _bus = Database.Session.Query<Bus>().ToList();
            var _sofor = Database.Session.Query<Sofor>().ToList();
            var _muavin = Database.Session.Query<Muavin>().ToList();

            return View("Form", new BusForm()
            {
                IsNew = true,
                Sofors = _sofor,
                Muavins = _muavin,
                Buses = _bus
            });
        }

        public ActionResult Edit(int id) // bus_id was working but now it doesn't. Have to convert it to id so i can pull the ID value from the url 
        {
            var bus = Database.Session.Load<BusInfo>(id);

            if (bus == null)
                return HttpNotFound();

            var _bus = Database.Session.Query<Bus>().ToList();
            var _sofor = Database.Session.Query<Sofor>().ToList();
            var _muavin = Database.Session.Query<Muavin>().ToList();

            return View("Form", new BusForm()
            {
                Muavins = _muavin,
                Sofors = _sofor,
                Buses = _bus,
                IsNew = false,
                _BusId = id,
                BusID = bus.BusID.ToString(),
                SoforID = bus.SoforID.ToString(), // Not sure how SoforID, MuavinID and BusID will react when for Dropdown list cause right now i'm returning an int value for their textboxes
                MuavinID = bus.MuavinID.ToString(),
                KalkisDest = bus.KalkisDest,
                VarisDest = bus.VarisDest,
                KalkisTime = bus.KalkisTime,
                VarisTime = bus.VarisTime,
                KalkisDate = bus.KalkisDate,
                KoltukSayisi = bus.KoltukSayisi,
                Fiyat = bus.Fiyat
            });
        }

        public ActionResult Delete(int id)
        {
            var _bus = Database.Session.Load<BusInfo>(id);

            if (_bus == null)
                return HttpNotFound();

            Database.Session.Delete(_bus);
            Database.Session.Flush();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Form(BusForm form)
        {
            if (form._BusId == null)
                form.IsNew = true;

            if (!ModelState.IsValid)
                return View(form);

            BusInfo _busInfo;
            
            if (form.IsNew)
            {
                _busInfo = new BusInfo()
                {
                    BusID = int.Parse(form.BusID), // Considering that they will return value attribute
                    SoforID = int.Parse(form.SoforID),
                    MuavinID = int.Parse(form.MuavinID),
                    KalkisDate = form.KalkisDate,
                    KalkisDest = form.KalkisDest,
                    VarisDest = form.VarisDest,
                    KalkisTime = form.KalkisTime,
                    VarisTime = form.VarisTime
                };
            }
            else
            {
                _busInfo = Database.Session.Load<BusInfo>(form._BusId);

                if (_busInfo == null)
                    return HttpNotFound();
            }

            _busInfo.KoltukSayisi = form.KoltukSayisi;
            _busInfo.Fiyat = form.Fiyat;

            Database.Session.SaveOrUpdate(_busInfo);
            Database.Session.Flush();

            return RedirectToAction("Index");
        }
    }
}