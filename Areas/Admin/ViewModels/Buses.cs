using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OtobusBiletiUygulamasi.Models;
using OtobusBiletiUygulamasi.Infrastructure;

namespace OtobusBiletiUygulamasi.Areas.Admin.ViewModels
{

    public class BusIndex
    {
        public PagedBuses<BusInfo> Buses { get; set; }    
    }

    public class BusForm
    {
        public bool IsNew { get; set; }

        public int? _BusId { get; set; }

        [Required]
        public string BusID { get; set; }

        public List<Bus> Buses { get; set; }

        [Required]
        public string SoforID { get; set; }

        public List<Sofor> Sofors { get; set; } // Will also contain SoforSoyad

        [Required]
        public string MuavinID { get; set; }

        public List<Muavin> Muavins { get; set; } // Will also contain MuavinSoyad

        [Required]
        public string KalkisDest { get; set; }

        [Required]
        public string VarisDest { get; set; }

        [Required]
        public string KalkisTime { get; set; }
        
        public string VarisTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? KalkisDate { get; set; }

        [Required]
        public int KoltukSayisi { get; set; }

        public int Fiyat { get; set; }
    }
}