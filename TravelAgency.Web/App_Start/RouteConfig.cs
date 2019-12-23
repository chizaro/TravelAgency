using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelAgency.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Tour info",
                url: "{controller}/{action}/{url}",
                defaults: new { controller = "Tours", action = "Details" },
                namespaces: new[] { "TravelAgency.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tours", action = "List", id = UrlParameter.Optional },
                namespaces: new[] { "TravelAgency.Web.Controllers" }
            );
        }
    }
}
