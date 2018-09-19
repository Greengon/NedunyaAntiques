using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using NedunyaAntiquesWebApp.Models;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Customers
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(string Email, string Password)
        {
            
            Customer cust = db.Customers.Find(Email);
            if (cust == null)
            {
                return HttpNotFound();
            }

            string message = string.Empty;
            if (cust.Password != Password)
                message = "הסיסמא אינה תקינה";
            else if (cust.Email != Email)
                message = "האימייל אינו תקין";
           else FormsAuthentication.SetAuthCookie(Email, cust.RememberMe);

            ViewBag.Message = message;
            return View(cust);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        // GET: Customers/Details/5
        // Using filter to allow access only to login users.
        //[Authorize] - TODO: uncomment before you go live
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Save
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Save()
        {
            return View();
        }

        // POST: Customers/Save
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,FisrtName")] Customer customer)
        {
            if (ModelState.IsValid)
            {   if(customer.Id==0)
                db.Customers.Add(customer);
                else
                {
                    var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.FisrtName = customer.FisrtName;
                    customerInDb.Birthdate = customer.Birthdate;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("CustomerForm", customer);
        }

        // GET: Customers/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FisrtName,IsSubscribed")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CustomerForm()
        {
            return View();
        }

        public ActionResult Customerlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: Map the view model to a domain model and pass to a repository
            // Personally I use and like AutoMapper very much (http://automapper.codeplex.com)

            return RedirectToAction("Success");
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
