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
            return View("Form", new BusForm() { IsNew = true});
        }

        public ActionResult Edit(int id) // bus_id was working but now it doesn't. Have to convert it to id so i can pull the ID value from the url 
        {
            var _bus = Database.Session.Load<BusInfo>(id);

            if (_bus == null)
                return HttpNotFound();

            return View("Form", new BusForm()
            {
                IsNew = false,
                _BusId = id,
                KalkisDest = _bus.KalkisDest,
                VarisDest = _bus.VarisDest,
                KalkisTime = _bus.KalkisTime,
                VarisTime = _bus.VarisTime,
                KalkisDate = _bus.KalkisDate,
                KoltukSayisi = _bus.KoltukSayisi,
                Fiyat = _bus.Fiyat
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
            // form.IsNew = form._BusId == null;

            if (form._BusId == null)
                form.IsNew = true;

            if (!ModelState.IsValid)
                return View(form);

            BusInfo _busInfo;
            
            if (form.IsNew)
            {
                _busInfo = new BusInfo()
                {
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


            /* Bu degerleri ViewModel'e ekleyecegim. Simdilik alltaki degerlerin CRUD'lari ile ugrasiyorum.
            _busInfo.SoforID = 1;
            _busInfo.MuavinID = 1;
            _busInfo.BusID = 1; */

            _busInfo.KoltukSayisi = form.KoltukSayisi;
            _busInfo.Fiyat = form.Fiyat;

            Database.Session.SaveOrUpdate(_busInfo);
            Database.Session.Flush();

            return RedirectToAction("Index");
        }

    }
}