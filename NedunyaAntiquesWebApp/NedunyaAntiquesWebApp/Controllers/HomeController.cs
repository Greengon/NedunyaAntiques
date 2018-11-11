using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NedunyaAntiquesWebApp.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            ViewBag.Message = "Your product shop page.";

            return RedirectToAction("ShowCategory", "Products");
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "זיהית בעיה באתר? שלח לנו הודעה.";

            return View();
        }

    }
}

/*
 *  string AdminId = "954da09c-478f-4012-bd0e-76180a40d039";
 * var userID = Session["userID"];
            if(userID != null && userID.ToString() == AdminId)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            return RedirectToAction("CustomerLog", "Customers");
            */
