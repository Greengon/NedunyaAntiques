using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NedunyaAntiquesWebApp.Models;
using NedunyaAntiquesWebApp.ViewModels;
using Microsoft.AspNet.Identity;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Transactions/ + Smart Search
        public async Task<ActionResult> Index(string dateStart, string dateEnd, string totalMin, string totalMax)
        {
            var transactions = from t in db.Transactions
                                select t;

            if(!String.IsNullOrEmpty(dateStart))
            {
                DateTime ds = Convert.ToDateTime(dateStart);
                transactions = transactions.Where(s => s.TransDate >= ds);
            }

            if (!String.IsNullOrEmpty(dateEnd))
            {
                DateTime de = Convert.ToDateTime(dateEnd);
                transactions = transactions.Where(s => s.TransDate <= de);
            }

            if (!String.IsNullOrEmpty(totalMax))
            {
                Decimal t = Convert.ToDecimal(totalMax);
                transactions = transactions.Where(s => s.Amount <= t);
            }

            if (!String.IsNullOrEmpty(totalMin))
            {
                Decimal t = Convert.ToDecimal(totalMin);
                transactions = transactions.Where(s => s.Amount >= t);
            }

            return View(await transactions.ToListAsync());
        }

        // GET: Transactions/AddressAndPayment/
        public ActionResult AddressAndPayment()
        {
            var userID = Session["userID"];
            if (userID != null)
            {
                Customer customer = db.Users.Single(user => user.Id == (string)userID);
                ShoppingCart shoppingCart = new ShoppingCart
                {
                    ShoppingCartId = customer.Id
                };
                Transaction transaction = shoppingCart.CreateTransaction(customer);
                customer.Transactions.Add(transaction);
                db.SaveChanges();
                if (transaction != null)
                {
                    TransactionViewModel transactionView = new TransactionViewModel
                    {
                        CartItems = db.Products.Where(product => product.CartId == customer.Id).ToList(),
                        amount = transaction.Amount
                    };
                    return View(transactionView);
                }
                else
                    return HttpNotFound();
            }
            return RedirectToAction("CustomerLog", "Customers");

        }


        // GET: Transactions/Complete/
        // You can get here only thourgh paypal
        public ActionResult Complete() { 
            var userID = Session["userID"];
            if (userID != null){
                    Customer customer = db.Users.Single(c => userID.ToString() == c.Id);
                    Transaction transaction = customer.Transactions.Last();
                    transaction.Paid = true;
                    var CartItems = db.Products.Where(product => product.CartId == customer.Id).ToList();
                    foreach (var item in CartItems)
                        item.sold = true;
                    db.SaveChanges();
            }
            else{
                return HttpNotFound();
            }
           

            return RedirectToAction("Index", "Home");
        } 

        // GET: Transactions/Failed
        // You can get here only thourgh paypal
        public ActionResult Failed()
        {
            var userID = Session["userID"];
            if (userID != null){
                    Customer customer = db.Users.Single(c => userID.ToString() == c.Id);
                    customer.Transactions.Remove(customer.Transactions.Last());
                    db.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        // Using filter to allow access only to login users.
        //[Authorize] - TODO: uncomment before you go live
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TransDate,Amount")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TransDate")] Transaction transaction)
        {
            if(db.Transactions.Find(transaction.TransactionId) != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transaction).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Response.Write(("<script>alert('Transaction was not found, please try another transaction');</script>"));
            }
            
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Transaction transaction = await db.Transactions.FindAsync(id);
            db.Transactions.Remove(transaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
