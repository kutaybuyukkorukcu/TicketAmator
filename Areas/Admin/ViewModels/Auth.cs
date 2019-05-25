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
        [Required]
        [DisplayName("Kullanıcı Adiniz")]
        public string Username { get; set; }

        [Required]
        [DataType("password")]
        [DisplayName("Kullanıcı şifre")]
        [MinLength(3)]
        public string Password { get; set; }
    }
}