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

    public class BusForm // Changed it to BusForm instead of BusNew
    {
        public bool IsNew { get; set; }
        public int? _BusId { get; set; } // Bunu ekleme sebebim Form sayfasinda hidden sekilde idsi gozuksun

        [Required, MaxLength(128)]
        public string KalkisDest { get; set; }

        [Required, MaxLength(128)]
        public string VarisDest { get; set; }

        [Required]
        public string KalkisTime { get; set; }
        
        [Required]
        public string VarisTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? KalkisDate { get; set; }

        [Required]
        public int KoltukSayisi { get; set; }

        [Required]
        public int Fiyat { get; set; }
    }
}