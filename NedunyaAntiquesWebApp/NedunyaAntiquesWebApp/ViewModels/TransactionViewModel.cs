using NedunyaAntiquesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.ViewModels
{
    public class TransactionViewModel
    {
        public List<Product> CartItems { get; set; }
        public decimal amount { get; set; }
    }
}