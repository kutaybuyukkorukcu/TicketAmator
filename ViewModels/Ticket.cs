using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.ViewModels
{
    public class BusTicket
    {
        public int Bus_ID { get; set; }
        public string YolcuAd { get; set; }
        public string YolcuSoyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int KoltukNo { get; set; }

        public string nereden { get; set; }
        public string nereye { get; set; }
        public string binisSaat { get; set; }
        public string inisSaat { get; set; }
        public DateTime? tarih { get; set; }
    }
}