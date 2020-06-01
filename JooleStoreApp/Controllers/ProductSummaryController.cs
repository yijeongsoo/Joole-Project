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
            Product prod = new Product{ ProductId = 1, SubcategoryId = 1, ManufacturerId = 1, ProductName = "Fan", Model = "Royal", ModelYear = 1996 , Series="1" , ProductImage=""};
            Product prod2 = new Product { ProductId = 2, SubcategoryId = 2, ManufacturerId = 2, ProductName = "Fan2", Model = "Feudal", ModelYear = 1920, Series = "2", ProductImage = "" };
            prodList.Add(prod);
            prodList.Add(prod2);

            return View("ProductSummary", prodList);
        }
    }
}