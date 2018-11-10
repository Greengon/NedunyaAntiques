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
        public string EmailLog { get; set; }

        public string PasswordLog { get; set; }

        public string UserLog { get; set; }

        public bool RemamberLog { get; set; }

        public string ReturnUrl { get; set; }
    }
}