using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Areas.Admin.ViewModels
{
    public class BusVehicleIndex
    {
        public List<Bus> Vehicles { get; set; }
    }

    public class BusVehicleForm
    {
        public bool IsNew { get; set; }

        public int? BusID { get; set; }

        [Required, MaxLength(45)]
        public string BusName { get; set; }

        [Required, MaxLength(45)]
        public string BusLicense{ get; set; }
    }
}