using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using TravelAgency.Web.Ninject;

namespace TravelAgency.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectConfiguration.Configure();
        }

        protected void Application_PostAuthenticateRequest()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var decodedTicket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                string role = decodedTicket.UserData;
                HttpContext.Current.User = new GenericPrincipal(HttpContext.Current.User.Identity, new string[] { role });
            }
        }
    }
}
