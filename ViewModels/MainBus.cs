using OtobusBiletiUygulamasi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.ViewModels
{
    public class BusSearch
    {
        public List<BusInfo> BusesToSearch { get; set; }
    }

    public class BusQuery
    {
        public string KalkisDest { get; set; }
        public string VarisDest { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? KalkisDate { get; set; }
    }
}



