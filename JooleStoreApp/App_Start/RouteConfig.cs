using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JooleStoreApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            // Login
            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            // Search
            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );

            // Product Detail
            routes.MapRoute(
                name: "Product Detail",
                url: "ProductDetail",
                defaults: new { controller = "ProductDetail", action = "Index", id = UrlParameter.Optional }
            );

            // Product Summary
            routes.MapRoute(
                name: "Product",
                url: "ProductSummary",
                defaults: new { controller = "ProductSummary", action = "Index", id = UrlParameter.Optional }
            );

            // Compare Product
            routes.MapRoute(
                name: "Compare Product",
                url: "CompareProduct",
                defaults: new { controller = "CompareProduct", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
