using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleStore_Service;
using JooleStoreApp.Models;

namespace JooleStoreApp.Controllers
{
    public class ProductSummaryController : Controller
    {
        // GET: ProductSummary
        public ActionResult Index()
        {
            GetProductSummary();
            return View("ProductSummary");
        }

        // TODO: change attribute to be model object
        public ActionResult GetProductSummary()
        {
            System.Diagnostics.Debug.WriteLine("Called function from controller");
            string prodId = 1.ToString();
            Service service = new Service();
            List<string> descriptionElements = service.GetProductDescription(prodId);

            // create a product model to generate description table
            Product prod = new Product();

            // list order: name, series, model
            prod.ProductName = descriptionElements[0];
            prod.Series = descriptionElements[1];
            prod.Model = descriptionElements[2];

            return View("ProductSummary", prod);
        }
    }
}