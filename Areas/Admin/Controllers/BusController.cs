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

            List<string> liste = new List<string>();

            string[] strArray = new string[82];

            strArray[0] = "Istanbul / Otogar";
            strArray[1] = "Adana";
            strArray[2] = "Adıyaman";
            strArray[3] = "Afyon";
            strArray[4] = "Ağrı";
            strArray[5] = "Amasya";
            strArray[6] = "Ankara";
            strArray[7] = "Antalya";
            strArray[8] = "Artvin";
            strArray[9] = "Aydın";
            strArray[10] = "Balıkesir";
            strArray[11] = "Bilecik";
            strArray[12] = "Bingöl";
            strArray[13] = "Bitlis";
            strArray[14] = "Bolu";
            strArray[15] = "Burdur";
            strArray[16] = "Bursa";
            strArray[17] = "Çanakkale";
            strArray[18] = "Çankırı";
            strArray[19] = "Çorum";
            strArray[20] = "Denizli";
            strArray[21] = "Diyarbakır";
            strArray[22] = "Edirne";
            strArray[23] = "Elazığ";
            strArray[24] = "Erzincan";
            strArray[25] = "Erzurum";
            strArray[26] = "Eskişehir";
            strArray[27] = "Gaziantep";
            strArray[28] = "Giresun";
            strArray[29] = "Gümüşhane";
            strArray[30] = "Hakkari";
            strArray[31] = "Hatay";
            strArray[32] = "Isparta";
            strArray[33] = "İçel";
            strArray[35] = "İstanbul";
            strArray[34] = "İzmir";
            strArray[36] = "Kars";
            strArray[37] = "Kastamonu";
            strArray[38] = "Kayseri";
            strArray[39] = "Kırklareli";
            strArray[40] = "Kırşehir";
            strArray[41] = "Kocaeli";
            strArray[42] = "Konya";
            strArray[43] = "Kütahya";
            strArray[44] = "Malatya";
            strArray[45] = "Manisa";
            strArray[46] = "Kahramanmaraş";
            strArray[47] = "Mardin";
            strArray[48] = "Muğla";
            strArray[49] = "Muş";
            strArray[50] = "Nevşehir";
            strArray[51] = "Niğde";
            strArray[52] = "Ordu";
            strArray[53] = "Rize";
            strArray[54] = "Sakarya";
            strArray[55] = "Samsun";
            strArray[56] = "Siirt";
            strArray[57] = "Sinop";
            strArray[58] = "Sivas";
            strArray[59] = "Tekirdağ";
            strArray[60] = "Tokat";
            strArray[61] = "Trabzon";
            strArray[62] = "Tunceli";
            strArray[63] = "Şanlıurfa";
            strArray[64] = "Uşak";
            strArray[65] = "Van";
            strArray[66] = "Yozgat";
            strArray[67] = "Zonguldak";
            strArray[68] = "Aksaray";
            strArray[69] = "Bayburt";
            strArray[70] = "Karaman";
            strArray[71] = "Kırıkkale";
            strArray[72] = "Batman";
            strArray[73] = "Şırnak";
            strArray[74] = "Bartın";
            strArray[75] = "Ardahan";
            strArray[76] = "Iğdır";
            strArray[77] = "Yalova";
            strArray[78] = "Karabük";
            strArray[79] = "Kilis";
            strArray[80] = "Osmaniye";
            strArray[81] = "Düzce";

            for (int i = 0; i < strArray.Length; i++)
            {
                liste.Add(strArray[i]);
            }

            return View("Form", new BusForm()
            {
                IsNew = true,
                Sofors = _sofor,
                Muavins = _muavin,
                Buses = _bus,
                Sehirler = liste
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

            List<string> liste = new List<string>();

            string[] strArray = new string[82];

            strArray[0] = "Istanbul";
            strArray[1] = "Ankara";
            strArray[2] = "Edirne";
            strArray[3] = "Afyon";
            strArray[4] = "Ağrı";
            strArray[5] = "Amasya";
            strArray[6] = "Adıyaman";
            strArray[7] = "Antalya";
            strArray[8] = "Artvin";
            strArray[9] = "Aydın";
            strArray[10] = "Balıkesir";
            strArray[11] = "Bilecik";
            strArray[12] = "Bingöl";
            strArray[13] = "Bitlis";
            strArray[14] = "Bolu";
            strArray[15] = "Burdur";
            strArray[16] = "Bursa";
            strArray[17] = "Çanakkale";
            strArray[18] = "Çankırı";
            strArray[19] = "Çorum";
            strArray[20] = "Denizli";
            strArray[21] = "Diyarbakır";
            strArray[22] = "Edirne";
            strArray[23] = "Elazığ";
            strArray[24] = "Erzincan";
            strArray[25] = "Erzurum";
            strArray[26] = "Eskişehir";
            strArray[27] = "Gaziantep";
            strArray[28] = "Giresun";
            strArray[29] = "Gümüşhane";
            strArray[30] = "Hakkari";
            strArray[31] = "Hatay";
            strArray[32] = "Isparta";
            strArray[33] = "İçel";
            strArray[35] = "Adana";
            strArray[34] = "İzmir";
            strArray[36] = "Kars";
            strArray[37] = "Kastamonu";
            strArray[38] = "Kayseri";
            strArray[39] = "Kırklareli";
            strArray[40] = "Kırşehir";
            strArray[41] = "Kocaeli";
            strArray[42] = "Konya";
            strArray[43] = "Kütahya";
            strArray[44] = "Malatya";
            strArray[45] = "Manisa";
            strArray[46] = "Kahramanmaraş";
            strArray[47] = "Mardin";
            strArray[48] = "Muğla";
            strArray[49] = "Muş";
            strArray[50] = "Nevşehir";
            strArray[51] = "Niğde";
            strArray[52] = "Ordu";
            strArray[53] = "Rize";
            strArray[54] = "Sakarya";
            strArray[55] = "Samsun";
            strArray[56] = "Siirt";
            strArray[57] = "Sinop";
            strArray[58] = "Sivas";
            strArray[59] = "Tekirdağ";
            strArray[60] = "Tokat";
            strArray[61] = "Trabzon";
            strArray[62] = "Tunceli";
            strArray[63] = "Şanlıurfa";
            strArray[64] = "Uşak";
            strArray[65] = "Van";
            strArray[66] = "Yozgat";
            strArray[67] = "Zonguldak";
            strArray[68] = "Aksaray";
            strArray[69] = "Bayburt";
            strArray[70] = "Karaman";
            strArray[71] = "Kırıkkale";
            strArray[72] = "Batman";
            strArray[73] = "Şırnak";
            strArray[74] = "Bartın";
            strArray[75] = "Ardahan";
            strArray[76] = "Iğdır";
            strArray[77] = "Yalova";
            strArray[78] = "Karabük";
            strArray[79] = "Kilis";
            strArray[80] = "Osmaniye";
            strArray[81] = "Düzce";

            for (int i = 0; i < strArray.Length; i++)
            {
                liste.Add(strArray[i]);
            }

            return View("Form", new BusForm()
            {
                Muavins = _muavin,
                Sofors = _sofor,
                Buses = _bus,
                Sehirler = liste,
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