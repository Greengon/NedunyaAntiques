﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Customer
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key]
        [Display(Name = "האימייל שלך")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "סיסמא")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "אשר סיסמא")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "הסיסמאות אינן תואמות, אנא נסה שנית")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "עיר מגורים")]
        public string CityAddress { get; set; }

        [Display(Name = "רחוב מגורים")]
        public string StreetAddress { get; set; }

        [Display(Name = "מספר בית")]
        public int HomeNum { get; set; }

        [Display(Name = "מספר דירה(אם לא בית פרטי)")]
        public int? AptNum { get; set; }

        [Required(ErrorMessage = "מספר הטלפון אינו חוקי")]
        [Display(Name = "פלאפון")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "מספר הטלפון אינו חוקי")]
        public int PhoneNum { get; set; }

        [Display(Name = "האם הינך מעוניין/ת שנעדכן אותך על מבצעים?")]
        public bool AdvertiseSalesNotification { get; set; }


        [Display(Name =  "תאריך הלידה שלך")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthdate { get; set; }


        [Display(Name = "זכור אותי")]
        public bool RememberMe { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}