using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Substance { get; set; }
        public string Category { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double?  Depth { get; set; }
        public bool Sale { get; set; }
        public bool Rented { get; set; }
        public string Description { get; set; }
    }
}