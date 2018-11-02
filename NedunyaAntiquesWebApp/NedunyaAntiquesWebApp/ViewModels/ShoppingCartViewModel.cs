/*
 * 
 * For great explanation on ViewModels see
 * https://stackoverflow.com/questions/11064316/what-is-viewmodel-in-mvc
 * 
 */

using NedunyaAntiquesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Product> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}