using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
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
            //ask a query in order to check if there is an admin  user un the db
            /*var user = (
        from u in db.Users
        where (u.UserName == "admin") && (u.PasswordHash == "adminadmin")

        select u).FirstOrDefault();
    if (user == null)
    {
        Customer AdminUser = new Customer
        {
            Email = "admin@gmail.com",
            UserName = "admin",
            PasswordHash = "adminadmin",
            FirstName = "admin",
            LastName = "admin",
            HomeNum = 1,
            PhoneNum = "050-111-1111",
        };
        var UserManager = HttpContext.GetOwinContext().GetUserManager<AppCustomerManager>();
        var result = UserManager.Create(AdminUser, AdminUser.PasswordHash);
        // if ((result.Succeeded))
        // {
        result = UserManager.AddToRole(AdminUser.Id, "Admin"); 
    }*/
            // db.Users.Add(AdminUser);
            // db.SaveChanges();
            //  }


        }

        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Index()
        {
            return View(db.Users.AsEnumerable().ToList());
        }

       

        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult LogIn(LoginViewModel login)
        {    
            if (ModelState.IsValid)
            {
                var user = (
                    from u in db.Users
                    where (u.UserName == login.UserLog) && (u.PasswordHash == login.PasswordLog)

                    select u).Single();

                var userManager = HttpContext.GetOwinContext().GetUserManager<AppCustomerManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                Customer customer = db.Users.Find(user.Id); 
                if (customer != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    var id = new ClaimsIdentity(claims,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    var ctx = Request.GetOwinContext();
                    var authenticationManager = ctx.Authentication;
                    authenticationManager.SignIn(id);
                    Session["UserID"] = user.Id.ToString();
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }


        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
           // HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
           //return RedirectToAction("Index", "Home");
        }

        //[Authorize] - TODO: uncomment before you go live
        public ActionResult Details(string Id)
        {
           
            Customer customer = db.Users.Find(Id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        
        public ActionResult Save()
        {
            return View();
        }

       
        [HttpPost]
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
                    if (customer.UserName == "admin")
                    {
                        if (customer.Email == "admin@gmail.com")
                        {
                            var AdminuserResult = UserManager.AddToRole(customer.Id, "Admin");
                            if (AdminuserResult.Succeeded)
                                return RedirectToAction("Index", "Home");
                        }

                    }
                    var userResult = UserManager.AddToRole(customer.Id, "NedunyaUser");
                    if(userResult.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
            }
            
            return View("CustomerForm", customer);
        }


        [Authorize(Roles = "NedunyaUser")]
        public ActionResult ChangePassword()
        {
            return View();
        }

      

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


         [HttpPost]
         public ActionResult Edit([Bind(Exclude = "RememberMe,Transactions")] Customer customer)
         {
             if (db.Users.Find(customer.Id) != null)
             {
                 if (ModelState.IsValid)
                 {
                     db.Entry(customer).State = EntityState.Modified;
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }
             }
             else
             {
                 Response.Write(("<script>alert('Customer was not found, please try another customer');</script>"));
             }

            return View(customer);
         }

        // [Authorize (Roles = "NedunyaUser")]
        
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
