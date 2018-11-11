using Microsoft.AspNet.Identity;
using NedunyaAntiquesWebApp.Models;
using NedunyaAntiquesWebApp.ViewModels;
using System;
using System.Linq;
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
            var userID = Session["UserID"];
            if (userID != null)
            {
                var cart = ShoppingCart.GetCart(userID.ToString());

                var viewModel = new ShoppingCartViewModel
                {
                    CartItems = cart.GetCartItems(),
                    CartTotal = cart.GetTotal()
                };
                return View(viewModel);
            }
            else
                return RedirectToAction("CustomerLog", "Customers");
        }
        
        // GET: ShoppingCart/AddToCart/id
        public ActionResult AddToCart(int id)
        {
            var userID = Session["UserID"];
            if (userID != null)
            {
                var addedProduct = db.Products.Single(product => product.ProductId == id);
                var cart = ShoppingCart.GetCart(userID.ToString());
                cart.AddToCart(addedProduct);
                return RedirectToAction("ShowCategory", "Products");
            }
            else
                return RedirectToAction("CustomerLog", "Customers");
        }

        // GET: ShoppingCart/RemoveFromCart/id
        public ActionResult RemoveFromCart(int id)
        {
            var userID = Session["UserID"];
            if (userID != null)
            {
                var cart = ShoppingCart.GetCart(userID.ToString());
                Product product = db.Products.FirstOrDefault(item => item.ProductId == id);
                cart.RemoveFromCart(product);
                return RedirectToAction("ShowCategory", "Products");
            }
            else
                return RedirectToAction("CustomerLog", "Customers");

        }

        /*
         * For [ChildActionOnly]
         * See https://stackoverflow.com/questions/10253769/using-childactiononly-in-mvc
         */
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var userID = Session["UserID"];
            if (userID != null)
            {
                var cart = ShoppingCart.GetCart(userID.ToString());

                ViewData["CartCount"] = cart.getCount();

                return PartialView("CartSummary");
            }
            else
                return RedirectToAction("CustomerLog", "Customers");
        }

        //https://stackoverflow.com/questions/10134406/why-is-there-need-for-an-explicit-dispose-method-in-asp-net-mvc-controllers-c
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}