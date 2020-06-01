using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleStoreApp.Controllers
{
    public class ProductSummaryController : Controller
    {
        // GET: ProductSummary
        public ActionResult Index()
        {
            List<Product> prodList = new List<Product>();
            Product prod = new Product{ ProductId = 1, SubcategoryId = 1, ManufacturerId = 1, ProductName = "Havels", Model = "Royal Model", ModelYear = 1996 , Series="Series 500" , ProductImage=""};
            Product prod2 = new Product { ProductId = 2, SubcategoryId = 2, ManufacturerId = 2, ProductName = "Philips", Model = "Feudal Model", ModelYear = 1920, Series = "Series 10", ProductImage = "" };
            prodList.Add(prod);
            prodList.Add(prod2);

            return View(prodList);
        }
    }
}