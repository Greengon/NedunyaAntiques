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
        public string ShoppingCartId { get; set; }

        public const String CartSessionKey = "cartId";


        // Funcs


        // GetCart will return an object of shopping cart with the userId as ShoppingCartId
       
        public static ShoppingCart GetCart(string UserId)
        { 
            var cart = new ShoppingCart();
            cart.ShoppingCartId = UserId;
            return cart;
        }



        public int AddToCart(Product product)
        {
            
            if (product.sold == false && product.inCart == false)
            {
                var addedProduct = db.Products.Single(p => product.ProductId == p.ProductId);
                addedProduct.CartId = ShoppingCartId;
                addedProduct.inCart = true;
                db.SaveChanges();
                return 0;
            }
            else
            {
                return -1;
            }

        }

        public int RemoveFromCart(Product product)
        {
            if (product.inCart == true)
            {
                var addedProduct = db.Products.Single(p => product.ProductId == p.ProductId);
                addedProduct.CartId = null;
                addedProduct.inCart = false;
                db.SaveChanges();
                return 0;
            }
            else
                return -1;
            
        }

        public void emptyCart()
        {
            var cartItems = db.Products.Where(product => product.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                RemoveFromCart(cartItem);
            }
            db.SaveChanges();
        }

        public List<Product> GetCartItems()
        {
            return db.Products.Where(Product => Product.CartId == ShoppingCartId).ToList();
        }

        public int getCount()
        {
            int? count = (
                from product in db.Products
                where product.CartId == ShoppingCartId
                select product
                ).Count();

            // ?? - this operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
            return count ?? -1;
        }

        public decimal GetTotal()
        {
            var list = new List<decimal>(from product in db.Products where product.CartId == ShoppingCartId select product.Price).ToList();
            if (list != null){
                // ?? - this operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
                return list.Sum();
            }
                else
                    return 0;
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

 



        public Transaction CreateTransaction(Customer customer)
        {
            var transcation = new Transaction
            {
               // customer = customer,
                Delivery = false,
                Paid = false,
                TransDate = DateTime.Now,
                Amount = this.GetTotal(),
                // Cart = this
            };

            db.Transactions.Add(transcation);
            db.SaveChanges();
            return transcation;
        }    
    }
}