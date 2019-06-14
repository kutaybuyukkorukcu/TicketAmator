using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OtobusBiletiUygulamasi.Models;

namespace OtobusBiletiUygulamasi.Areas.Admin.ViewModels
{
    public class CrewIndexDriver
    {
        public List<Sofor> Drivers { get; set; } 
    }

    public class CrewIndexAssistant
    {
        public List<Muavin> Assistants { get; set; }
    }

    public class CrewForm
    {
        public bool IsDriver { get; set; } // to check whether it's the sofor or muavin

        public bool IsNew { get; set; }

        public int? CrewID { get; set; }

        [Required, MaxLength(45)]
        public string Ad { get; set; }

        [Required, MaxLength(45)]
        public string Soyad { get; set; }

        [Required, MaxLength(45)]
        public string TC { get; set; }

        [Required, MaxLength(45)]
        public string Numara { get; set; }
        
        // public bool IsFree { get; set; } Not using IsFree atm.
    }
}