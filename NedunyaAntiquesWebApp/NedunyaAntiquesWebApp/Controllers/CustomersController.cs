using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NedunyaAntiquesWebApp.Models;
using NedunyaAntiquesWebApp.ViewModels;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private void CreateRoles()
        {
            //Creating User role
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
            string roleUserName = "NedunyaUser";
            if (!roleManager.RoleExists(roleUserName))
                roleManager.Create(new AppRole(roleUserName));
            //Cerating Admin role
            string roleAdminName = "Admin";
            if (!roleManager.RoleExists(roleAdminName))
                roleManager.Create(new AppRole(roleAdminName));
        }

        // GET: Customers
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

       

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppCustomerManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                Customer customer = userManager.Find(login.Email, login.Password);
                if (customer != null)
                {
                    var ident = userManager.CreateIdentity(customer,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    FormsAuthentication.SetAuthCookie(customer.Email, customer.RememberMe);
                    //use the instance that has been created. 
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }


        // POST: /Customers/Logout
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        // GET: Customers/Details/5
        // Using filter to allow access only to login users.
        //[Authorize] - TODO: uncomment before you go live
        public ActionResult Details(int Id)
        {
           
            Customer customer = db.Users.Find(Id);
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

       
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveClient([Bind(Exclude = "RememberMe,Transactions")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CreateRoles();
                Customer cust = db.Users.Find(customer.Id);
                if (cust == null)
                {
                    db.Users.Add(customer);
                    db.SaveChanges();
                    var UserManager = HttpContext.GetOwinContext().GetUserManager<AppCustomerManager>();
                    var userResult = UserManager.AddToRole(customer.Id, "NedunyaUser");
                    if(userResult.Succeeded)
                        return RedirectToAction("Index", "Home");

                    //return RedirectToAction("Index");
                }
            }
            
            return View("CustomerForm", customer);
        }


        [Authorize(Roles = "NedunyaUser")]
        public ActionResult ChangePassword()
        {
            return View();
        }

      

        // GET: Customers/Edit/5
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Edit(string Id)
        {
           
            Customer customer = db.Users.Find(Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "Email,Password")] Customer customer)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(customer).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(customer);
         }*/

        // GET: Customers/Delete/5
        // Using filter to allow access only to admin users.
        // [Authorize (Roles = "NedunyaUser")]
         [HttpPost]
         public ActionResult Delete(string Id)
         {
             Customer customer = db.Users.Find(Id);
            db.Users.Remove(customer);
             db.SaveChanges();
             
             return RedirectToAction("Index");
         }


        public ActionResult CustomerForm()
        {
            return View();
        }

        public ActionResult CustomerLog()
        {
            return View();
        }
        public ActionResult ChangePasswordForm()
        {
            return View();
        }
        public ActionResult CreateLoginViewModel()
        {
            LoginViewModel login = new LoginViewModel();

            return View(login);
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
