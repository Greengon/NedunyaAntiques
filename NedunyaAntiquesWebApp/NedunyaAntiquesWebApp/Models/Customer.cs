using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Customer
    { public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "נא הזן את שמך")]
        public string Name { get; set; }
        [Display(Name = "האם הינך מנוי?")]
        public bool IsSubscribed { get; set; }
        [Display(Name =  "תאריך הלידה שלך")]
        public DateTime Birthdate { get; set; }
    }
}