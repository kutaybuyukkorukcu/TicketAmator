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

            for(int i = 0; i < strArray.Length; i++)
            {
                liste.Add(strArray[i]);
            }
            
            return View("Index", new BusQuery()
            {
                Sehirler = liste
            });
        }

       [HttpPost]
        public ActionResult Index(BusQuery form)
        {
            var _bus = Database.Session.Query<BusInfo>()
                .Where(u => u.KalkisDest == form.KalkisDest)
                .Where(u => u.VarisDest == form.VarisDest)
                .Where(u => u.KalkisDate == form.KalkisDate)
                .ToList();

            if (form.KalkisDest == null)
            {
                ModelState.AddModelError("KalkisDest", "Kalkis ve Varis degerlerini giriniz!");
                return View(form);
            }

            if (form.KalkisDest == form.VarisDest)
            {
                ModelState.AddModelError("KalkisDest", "Kalkis ve Varis degerlerini ayni girdiniz!");
                return View(form);
            }

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