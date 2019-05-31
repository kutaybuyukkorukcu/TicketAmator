using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtobusBiletiUygulamasi.Areas.Admin.ViewModels
{
    public class AuthLogin
    {
        [DisplayName("Kullanıcı Adi :")]
        public string Username { get; set; }

        [DataType("password")]
        [DisplayName("Kullanıcı Sifresi :")]
        [MinLength(3)]
        public string Password { get; set; }
    }
}