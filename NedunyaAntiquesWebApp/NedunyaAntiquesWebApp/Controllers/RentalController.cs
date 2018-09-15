using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NedunyaAntiquesWebApp.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        // Using filter to allow access only to admin users.
        //[Authorize (Roles ="administor")] - TODO: uncomment before you go live
        public ActionResult Index()
        {
            return View();
        }
    }
}