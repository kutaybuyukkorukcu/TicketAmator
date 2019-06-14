using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtobusBiletiUygulamasi.Areas.Admin.ViewModels;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CrewController : Controller
    {
        public ActionResult Driver()
        {
            var _driver = Database.Session.Query<Sofor>().ToList();

            if (_driver.Count == 0)
            {
                ModelState.AddModelError("SoforAd", "Sirkette sofor bulunmamaktadir.");
                return View();
            }

            return View(new CrewIndexDriver()
            {
                Drivers = _driver
            });
        }

        public ActionResult Assistant()
        {
            var _assistant = Database.Session.Query<Muavin>().ToList();

            if (_assistant.Count == 0)
            {
                ModelState.AddModelError("MuavinAd", "Sirkette muavin bulunmamaktadir.");
                return View();
            }

            return View(new CrewIndexAssistant()
            {
                Assistants = _assistant
            });
        }

        public ActionResult NewDriver()
        {
            return View("Form", new CrewForm
            {
                IsDriver = true,
                IsNew = true
            });
        }

        public ActionResult NewAssistant()
        {
            return View("Form", new CrewForm
            {
                IsDriver = false,
                IsNew = true
            });
        }

        public ActionResult EditDriver(int id)
        {
            var _driver = Database.Session.Load<Sofor>(id);

            if (_driver == null)
                return HttpNotFound();

            return View("Form", new CrewForm()
            {
                IsDriver = true,
                IsNew = false,
                CrewID = id,
                Ad = _driver.SoforAd,
                Soyad = _driver.SoforSoyad,
                TC = _driver.SoforTC,
                Numara = _driver.SoforNumara
            });
        }

        public ActionResult EditAssistant(int id)
        {
            var _assistant = Database.Session.Load<Muavin>(id);

            if (_assistant == null)
                return HttpNotFound();

            return View("Form", new CrewForm()
            {
                IsDriver = false,
                IsNew = false,
                CrewID = id,
                Ad = _assistant.MuavinAd,
                Soyad = _assistant.MuavinSoyad,
                TC = _assistant.MuavinTC,
                Numara = _assistant.MuavinNumara
            });
        }

        public ActionResult DeleteDriver(int id)
        {
            var _driver = Database.Session.Load<Sofor>(id);

            if (_driver == null)
                return HttpNotFound();

            Database.Session.Delete(_driver);
            Database.Session.Flush();

            return RedirectToAction("Driver");
        }

        public ActionResult DeleteAssistant(int id)
        {
            var _assistant = Database.Session.Load<Muavin>(id);

            if (_assistant == null)
                return HttpNotFound();

            Database.Session.Delete(_assistant);
            Database.Session.Flush();

            return RedirectToAction("Assistant");
        }

        [HttpPost]
        public ActionResult FormDriver(CrewForm form)
        {
            if (form.CrewID == null)
                form.IsNew = true;

            if (!ModelState.IsValid)
                return View(form);

            Sofor _sofor;

            if (form.IsNew)
            {
                _sofor = new Sofor()
                {
                    SoforTC = form.TC
                };
            }
            else
            {
                _sofor = Database.Session.Load<Sofor>(form.CrewID);

                if (_sofor == null)
                    return HttpNotFound();
            }

            _sofor.SoforAd = form.Ad;
            _sofor.SoforSoyad = form.Soyad;
            _sofor.SoforNumara = form.Numara;

            Database.Session.SaveOrUpdate(_sofor);
            Database.Session.Flush();

            return RedirectToAction("Driver");
        }

        [HttpPost]
        public ActionResult FormAssistant(CrewForm form)
        {
            // Editten crewID'yi bu forma aktaramadim bundan dolayi edit yaptigim zaman eskisi ayni kalip, yeni bir seymis gibi yeni bir tane uretiyor.
            // Simdilik varolan kayidi silip, yeni yaratacagim.

            // I forgot to put ID (If !IsNew) in the form. That's why i struggled.

            if (form.CrewID == null) // I cant pass CrewID into this function so crewId is null which makes IsNew true everytime.
                form.IsNew = true;

            if (!ModelState.IsValid)
                return View(form);

            Muavin _muavin;

            if (form.IsNew)
            {
                _muavin = new Muavin()
                {
                    MuavinTC = form.TC
                };
            }
            else
            {
                _muavin = Database.Session.Load<Muavin>(form.CrewID);

                if (_muavin == null)
                    return HttpNotFound();
            }
            
            _muavin.MuavinAd = form.Ad;
            _muavin.MuavinSoyad = form.Soyad;
            _muavin.MuavinNumara = form.Numara;

            Database.Session.SaveOrUpdate(_muavin);
            Database.Session.Flush();

            return RedirectToAction("Assistant");
        }
    }
}