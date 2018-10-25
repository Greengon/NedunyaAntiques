using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NedunyaAntiquesWebApp.Models;

namespace NedunyaAntiquesWebApp.ViewModels
{
    public class LoginViewModel : Customer
    {
       

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
        public string ReturnUrl { get; set; }
    }
}