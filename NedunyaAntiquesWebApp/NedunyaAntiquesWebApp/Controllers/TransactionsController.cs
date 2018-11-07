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

namespace NedunyaAntiquesWebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            return View(await db.Transactions.ToListAsync());
        }

        // GET: Transactions/AddressAndPayment
        public ActionResult AddressAndPayment(Customer customer)
        {
            ShoppingCart shoppingCart = new ShoppingCart
            {
                ShoppingCartId = customer.Id
            };
            Transaction transaction = shoppingCart.CreateTransaction(customer);
            customer.Transactions.Add(transaction);
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


        // GET: Transactions/Complete/
        // You can get here only thourgh paypal
        public ActionResult Complete()
        {
            /*TODO : find how to get userId of a logged in user
             *DO NOT DELETE
             * var userID = User.Identity.GetUserId();
                if (userID != null){
                     customer = db.Customer.single(c => userID == c.ID);
                     Transaction transaction = customer.transaction.pop();
                     transaction.paid = ture;
                     var CartItems = db.Products.Where(product => product.CartId == customer.Id).ToList();
                     foreach (var item in CartItems)
                        item.sold = true;
                     customer.transaction.add(transaction);
            }
            else{
                return httpNotFound();
            }
             
             */


            return RedirectToAction("Index", "Home");
        } 

        // GET: Transactions/Failed
        // You can get here only thourgh paypal
        public ActionResult Failed()
        {
            /* TODO : find how to get userId of a logged in user
             *DO NOT DELETE
             * 
             * var userID = User.Identity.GetUserId();
                if (userID != null){
                     customer = db.Customer.single(c => userID == c.ID);
             *       Transaction transaction = customer.transaction.pop();
             }
             */
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
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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


        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
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
