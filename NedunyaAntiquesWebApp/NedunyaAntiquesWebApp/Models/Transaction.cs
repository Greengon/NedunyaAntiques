using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public bool Rented { get; set; }
        public bool Soled { get; set; }
        public DateTime TransacDate { get; set; }
    }
}