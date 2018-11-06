using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class AppCustomerManager : UserManager<Customer>
    {
        public AppCustomerManager(IUserStore<Customer> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppCustomerManager Create(
            IdentityFactoryOptions<AppCustomerManager> options, IOwinContext context)
        {
            var manager = new AppCustomerManager(
                new UserStore<Customer>(context.Get<ApplicationContext>()));
            // optionally configure your manager
            // ...

            return manager;
        }
    }
    
}