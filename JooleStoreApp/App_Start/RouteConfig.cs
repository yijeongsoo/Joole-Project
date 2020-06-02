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

            // Login
            routes.MapRoute(
                name: "Login1",
                url: "Login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login Function",
                url: "Login/Login",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login2",
                url: "Login/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            // Search
            routes.MapRoute(
                name: "Search1",
                url: "Search",
                defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search2",
                url: "Search/OnSearch",
                defaults: new { controller = "Search", action = "OnSearch", id = UrlParameter.Optional }
            );

            // Product Detail
            routes.MapRoute(
                name: "Product Detail1",
                url: "ProductDetail",
                defaults: new { controller = "ProductDetail", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product Detail2",
                url: "ProductDetail/{id}",
                defaults: new { controller = "ProductDetail", action = "Index", id = UrlParameter.Optional }
            );

            // Product Summary
            routes.MapRoute(
                name: "Product1",
                url: "ProductSummary",
                defaults: new { controller = "ProductSummary", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product2",
                url: "ProductSummary/{id}",
                defaults: new { controller = "ProductSummary", action = "Index", id = UrlParameter.Optional }
            );

            // Compare Product
            routes.MapRoute(
                name: "Compare Product1",
                url: "CompareProduct",
                defaults: new { controller = "CompareProduct", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Compare Product2",
                url: "CompareProduct/{id}",
                defaults: new { controller = "CompareProduct", action = "Index", id = UrlParameter.Optional }
            );

            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
