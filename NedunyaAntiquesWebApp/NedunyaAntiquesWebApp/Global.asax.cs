using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NedunyaAntiquesWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*
         * https://www.youtube.com/watch?v=kygRLho8WwQ
         * default error page where user will be redirected if unexpected error happens
         * TODO : return custom error page after we done, change error view name and
         * create another controller and view
         * 
         */
        /*
       protected void Application_Error(object sender , EventArgs e)
       {
           Exception exc = Server.GetLastError();
           Server.ClearError();
           Response.Redirect("/ErrorPage/ErrorMessage");
       }
       */
    }
}
