using NedunyaAntiquesWebApp.Models;
using NedunyaAntiquesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        public string shoppingCartId { get; set; }

        // GET: ShoppingCart
       
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }
        
        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(product => product.ProductId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct);
            return RedirectToAction("Shop");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            Product product = db.Products.FirstOrDefault(item => item.ProductId == id);
            int itemCount = cart.RemoveFromCart(product);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(product.Name) + " has been removed from your shopping cart",
                CartTotal = cart.GetTotal(),
                CartCount = cart.getCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        /*
         * For [ChildActionOnly]
         * See https://stackoverflow.com/questions/10253769/using-childactiononly-in-mvc
         */
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.getCount();

            return PartialView("CartSummary");
        }
    }
}