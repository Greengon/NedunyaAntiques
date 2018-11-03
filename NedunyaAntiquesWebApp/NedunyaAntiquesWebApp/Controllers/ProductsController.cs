using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NedunyaAntiquesWebApp.Models;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();


        // GET: Products
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //GET : Products/Show
        public ActionResult ShowCategory(string category)
        {

            // List<Product> _productList;
            var productList = from p in db.Products where p.Category.Equals(category) select p;
            if (!productList.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Category=category;
            return View(productList.ToList());
         }
        
        public ActionResult ShowProdOnSale()
        {
            var productList = from p in db.Products where p.Sale.Equals(true) select p;
            if (!productList.Any())
             {
                return RedirectToAction("Index","Home");
             }
            return View(productList.ToList());
        }



        // GET: Products/Save
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Save
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price,Substance,Category,SubCategory,Height,Width,Depth,Sale,DiscountPercentage,Rented,RentalPriceForDay,Description")] Product product, IEnumerable<HttpPostedFileBase> Images)
        {
            if (ModelState.IsValid)
            {
                if (Images.ElementAt(0)!= null)
                {
                    var imageList = new List<Image>();
                
                    foreach (var image in Images)
                    {
                        string imageName = System.IO.Path.GetFileName(image.FileName);
                        string physicalPath = Server.MapPath("~/Images/" + imageName);
                        image.SaveAs(physicalPath);
                        WebImage photo = new WebImage(physicalPath);
                        photo.Resize(640, 480);
                        photo.Save("~/Images/Thumbs/" + imageName);
                        var img = new Image { ProductId = product.ProductId};                        
                        img.Name = imageName;
                        imageList.Add(img);
                     }
                   
                    product.Images = imageList;
                }
                else
                {
                    return RedirectToAction("Create");
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price,Substance,Category,SubCategory,Height,Width,Depth,Sale,DiscountPercentage,Rented,RentalPriceForDay,Description")] Product product, IEnumerable<HttpPostedFileBase> Images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
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
