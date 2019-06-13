using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.Models;
using OtobusBiletiUygulamasi.Areas.Admin.ViewModels;

namespace OtobusBiletiUygulamasi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            var _bus = Database.Session.Query<Bus>().ToList();

            if (_bus.Count == 0)
            {
                ModelState.AddModelError("BusName", "Sirkette sofor bulunmamaktadir.");
                return View();
            }

            return View(new BusVehicleIndex()
            {
                Vehicles = _bus
            });
        }

        public ActionResult New()
        {
            return View("Form", new BusVehicleForm()
            {
                IsNew = true
            });
        }

        public ActionResult Edit(int id)
        {
            var _vehicle = Database.Session.Load<Bus>(id);

            if (_vehicle == null)
                return HttpNotFound();

            return View("Form", new BusVehicleForm()
            {
                IsNew = false,
                BusID = id,
                BusName = _vehicle.BusName,
                BusLicense = _vehicle.BusLicense
            });
        }

        public ActionResult Delete(int id)
        {
            var _vehicle = Database.Session.Load<Bus>(id);

            if (_vehicle == null)
                return HttpNotFound();

            Database.Session.Delete(_vehicle);
            Database.Session.Flush();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Form(BusVehicleForm form)
        {
            if (form.BusID == null)
                form.IsNew = true;

            if (!ModelState.IsValid)
                return View(form);

            Bus _bus;

            if (form.IsNew)
            {
                _bus = new Bus()
                {
                    BusName = form.BusName
                };
            }
            else
            {
                _bus = Database.Session.Load<Bus>(form.BusID);

                if (_bus == null)
                    return HttpNotFound();
            }

            Database.Session.CreateSQLQuery("Delete from bus where BusName = :BusName")
                .SetParameter("BusName", form.BusName)
                .UniqueResult();
            Database.Session.Flush();

            _bus.BusLicense = form.BusLicense;

            Database.Session.SaveOrUpdate(_bus);
            Database.Session.Flush();

            return RedirectToAction("Index");
        }
    }
}