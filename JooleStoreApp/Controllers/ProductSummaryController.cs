using System;
using System.Collections.Generic;
using System.Dynamic;
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

            // list order: name, series, model, model year
            prod.ProductName = descriptionElements[0];
            prod.Series = descriptionElements[1];
            prod.Model = descriptionElements[2];
            prod.ModelYear = int.Parse(descriptionElements[3]);

            // test: hardcode a tblTypeRange object
            tblTypeRange typeRange = new tblTypeRange();
            typeRange.TypeName = "Resolution (Hardcoded)";
            typeRange.TypeOptions = "1080 (Hardcoded)";
            tblTypeRange typeRange2 = new tblTypeRange();
            typeRange2.TypeName = "Screen Size (Hardcoded)";
            typeRange2.TypeOptions = "24'' (Hardcoded)";

            /* create lists for Product and tblTypeRange
               depiste having one object only, we need to create a list in order for the dynamic model
               and table rendering to work properly */
            List<Product> prodList = new List<Product>();
            prodList.Add(prod);
            List<tblTypeRange> typeRangeList = new List<tblTypeRange>();
            typeRangeList.Add(typeRange);
            typeRangeList.Add(typeRange2);

            // add both models to a dynamic model
            dynamic productSummaryModel = new ExpandoObject();
            productSummaryModel.Products = prodList;
            productSummaryModel.TypeRanges = typeRangeList;

            return View("ProductSummary", productSummaryModel);
        }
    }
}