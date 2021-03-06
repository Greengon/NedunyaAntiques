﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using NedunyaAntiquesWebApp.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NedunyaAntiquesWebApp
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            //UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            app.CreatePerOwinContext(() => new ApplicationContext());
            app.CreatePerOwinContext<AppCustomerManager>(AppCustomerManager.Create);
            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<ApplicationContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Customers/CustomerLog"),
            });
        }
    }
}