using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "שם המוצר")]
        public string Name { get; set; }

        [Display(Name = "מחיר")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
        [Required]
        [Display(Name = "חומר גלם")]
        public string Substance { get; set; }
        [Required]
        [Display(Name = "קטגוריה")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "תת-קטגוריה")]
        public string SubCategory { get; set; }

        [Display(Name = "גובה")]
        public double? Height { get; set; }

        [Display(Name = "רוחב")]
        public double? Width { get; set; }

        [Display(Name = "עומק")]
        public double?  Depth { get; set; }

        [Display(Name = "האם במבצע")]
        public bool Sale { get; set; }

        [Display(Name = "אחוז הנחה")]
        [Range(1, 100)]
        public uint DiscountPercentage { get; set; }

        [Display(Name = "האם ניתן להשכרה")]
        public bool Rented { get; set; }
        [Required]
        [Display(Name = "תיאור המוצר")]
        public string Description { get; set; }

        public virtual Transaction Transaction { get; set; }

        [Display(Name = "הוסף תמונה/ות")]
        public virtual ICollection<Image> Images { get; set; }
    }
}