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

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View("~/Views/Cart/Create.cshtml");
        }

        // GET: ShoppingCart/Delete
        public ActionResult Delete()
        {
            return View("~/Views/Cart/Delete.cshtml");
        }

        // GET: ShoppingCart/Edit
        public ActionResult Edit()
        {
            return View("~/Views/Cart/Edit.cshtml");
        }

        // GET: ShoppingCart/List
        public ActionResult List()
        {
            return View("~/Views/Cart/Edit.cshtml");
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Products.Single(product => product.ProductId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string productName = db.Carts.FirstOrDefault(item => item.ProductId == id).Product.Name;
            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + " has been removed from your shopping cart",
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