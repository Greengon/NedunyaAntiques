using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 This class is almost a copy of 
 https://github.com/shakeelosmani/MvcAffableBean/blob/master/MvcAffableBean/Models/ShoppingCart.cs
 TODO: work on it to adjust it to our project.
     
 Shopping cart doesnt shown as a db table.
     */
namespace NedunyaAntiquesWebApp.Models
{
    public class ShoppingCart
    {
        // Database
        ApplicationContext db = new ApplicationContext();


        // Data
        public String ShoppingCartId { get; set; }

        public const String CartSessionKey = "cartId";


        // Funcs

        public static ShoppingCart GetCart(HttpContextBase context)
        { //HttpContextBase - Serves as the base class for classes that contain HTTP-specific information about an individual HTTP request.
            var cart = new ShoppingCart();

            // There is GetCartId method in this class.
            cart.ShoppingCartId = cart.GetCartId(context);

            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            // SingleOrDefault - Returns a single, specific element of a sequence, or a default value if that element is not found.
            var cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.ProductId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ProductId = product.ProductId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                /*
                 *TODO: We need to chek if this else is needed here,
                 * where there is no duplicated products.
                 */
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // SingleOrDefault - Returns a single, specific element of a sequence, or a default value if that element is not found.
            var cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                /*
                *TODO: We need to chek if this if statement is needed here,
                * where there is no duplicated products.
                */
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                db.SaveChanges();
            }
            return itemCount;
        }

        public void emptyCart()
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int getCount()
        {
            int? count = (
                from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select (int?)cartItems.Count
                ).Sum();

            // ?? - this operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (
                from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select (int?)cartItems.Count * cartItems.Product.Price)
                .Sum();

            // ?? - this operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
            return total ?? decimal.Zero;
        }

        // GetCartId will return CartId or will create one
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Guid - This class represents a globally unique identifier.
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string Email)
        {
            var shoppingCart = db.Carts.Where(c => c.CartId == ShoppingCartId);
            foreach(Cart item in shoppingCart)
            {
                item.CartId = Email;
            }

            db.SaveChanges();
        }

        /*
        * Here needs to come CreateOrder 
        * Which uses CustomerOrder
        * and OrderedProduct which we dont have
        * TODO: create this possiblity
        * 
        */
    }
}