using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "נא ציין/י את שמך")]
        public string FisrtName { get; set; }

        [Display(Name = "נא ציין/י את שם משפחתך")]
        public string LastName { get; set; }

        [Display(Name = "נא ציין/י את עיר מגוריך")]
        public string CityAddress { get; set; }

        [Display(Name = "נא ציין/י את רחוב מגוריך")]
        public string StreetAddress { get; set; }

        [Display(Name = "נא ציין/י את מספר ביתך")]
        public int HomeNum { get; set; }

        [Display(Name = "נא ציין/י את מספר דירתך")]
        public int AptNum { get; set; }

        [Display(Name = "האם הינך מנוי/ה?")]
        public bool IsSubscribed { get; set; }

        [Display(Name =  "תאריך הלידה שלך")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "האימייל שלך")]
        public string Email { get; set; }
    }
}