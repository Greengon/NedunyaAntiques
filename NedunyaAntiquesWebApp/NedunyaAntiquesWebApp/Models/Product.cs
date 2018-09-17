using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public Double? PriceAfterDiscount { get; set; }
        public string Substance { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double?  Depth { get; set; }
        public bool Sale { get; set; }
        public bool Rented { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
    }
}