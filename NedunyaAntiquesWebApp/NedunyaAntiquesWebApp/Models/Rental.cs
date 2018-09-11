using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Rental
    {
        public int Id { get; set; }

        
        public Customer Customer { get; set; }
        
        public Product Product { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}