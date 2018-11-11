using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NedunyaAntiquesWebApp.Models;

namespace NedunyaAntiquesWebApp.ViewModels
{
    public class LoginViewModel 
    {
        [Display(Name = "אימייל")]
        public string EmailLog { get; set; }

        [Display(Name = "סיסמא")]
        public string PasswordLog { get; set; }

        [Display(Name = "שם משתמש")]
        public string UserLog { get; set; }

        public bool RemamberLog { get; set; }

        public string ReturnUrl { get; set; }
    }
}