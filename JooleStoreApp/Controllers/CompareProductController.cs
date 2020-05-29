using JooleStore_Service;
using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JooleStoreApp.Controllers
{
    public class CompareProductController : Controller
    {
        // GET: CompareProduct
        public ActionResult Index()
        {
            return View("CompareProduct");
        }

        public ActionResult CompareProductHelper(Product product1, Product product2)
        {
            Service service = new Service();
            List<Product> ProductList = new List<Product>();
            //Call Service Layer functions to get both product infos
            List<string> Product1HelpList = service.FindProduct(product1.ProductName);
            List<string> Product2HelpList = service.FindProduct(product2.ProductName);
            // if both products are in the database
            if (Product1HelpList[0] == "Yes" && Product2HelpList[0] == "Yes") {
                Product Product1 = new Product
                {
                    ProductId = Int32.Parse(Product1HelpList[1]),
                    ManufacturerId = Int32.Parse(Product1HelpList[2]),
                    SubcategoryId = Int32.Parse(Product1HelpList[3]),
                    ProductName = Product1HelpList[4],
                    ProductImage = Product1HelpList[5],
                    Series = Product1HelpList[6],
                    ModelYear = Int32.Parse(Product1HelpList[7]),
                    Model = Product1HelpList[8],
                };
                ProductList.Add(Product1);

                Product Product2 = new Product
                {
                    ProductId = Int32.Parse(Product2HelpList[1]),
                    ManufacturerId = Int32.Parse(Product2HelpList[2]),
                    SubcategoryId = Int32.Parse(Product2HelpList[3]),
                    ProductName = Product2HelpList[4],
                    ProductImage = Product2HelpList[5],
                    Series = Product2HelpList[6],
                    ModelYear = Int32.Parse(Product2HelpList[7]),
                    Model = Product2HelpList[8],
                };
                ProductList.Add(Product2);
            }
            return View("CompareProduct", "CompareProduct", ProductList);
        }
        public ActionResult CompareProduct(List<Product> ProductList)
        {
            return View(); 
        }
    }
}