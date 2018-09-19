using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Customer
    {
        
        public int Id { get; set; }
        
        

        [Required]
        [Display(Name = "סיסמא")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "הסיסמאות אינן תואמות, אנא נסה שוב !")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "שם פרטי")]
        [StringLength(50)]
        [Required]
        public string FisrtName { get; set; }

        [Display(Name = "שם משפחה")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "עיר מגורים")]
        [Required]
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
        [Key]
        [Display(Name = "אימייל")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public Nullable<System.DateTime> LastLoginDate { get; set; }

        public bool RememberMe { get; set; }
    }
}