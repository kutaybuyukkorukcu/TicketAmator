using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OtobusBiletiUygulamasi.Controllers;

namespace OtobusBiletiUygulamasi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var namespaces = new[] { typeof(HomeController).Namespace };

            /* routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); */

            routes.MapRoute("Home", "", new { Controller = "Home", Action = "Index" }, namespaces);
            routes.MapRoute("Routes", "Routes", new { Controller = "Home", Action = "Routes" }, namespaces);
            routes.MapRoute("Bilet Alimi", "BuyTicket", new { Controller = "Seat", Action = "BusSeat" });
            routes.MapRoute("Bilet", "Sold", new { Controller = "Seat", Action = "Sold" });
        }
    }
}
