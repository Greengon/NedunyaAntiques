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

        public ActionResult shop()
        {
            ViewBag.Message = "Your product shop page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "זיהתה בעיה באתר? שלח לנו הודעה.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            //TODO: send messaage to HQ
            ViewBag.TheMessage = "תודה. הודעתך התקבלה.";

            return View();
        }

    }
}