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
        // use a dynamic model to display multiple models in the view
        public dynamic productSummaryModel = new ExpandoObject();

        // GET: ProductSummary
        public ActionResult Index()
        {
            GetProductSummary();
            return View("ProductSummary");
        }

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

            /* add product to a list
               depiste having one object only, we need to create a list in order for the dynamic model
               and table rendering to work properly */
            List<Product> prodList = new List<Product>();
            prodList.Add(prod);

            // add add the above list to the dynamic model
            productSummaryModel.Products = prodList;

            // get product type info
            GetProductTypeInfo();

            // get tech specs
            GetTechSpecs();

            return View("ProductSummary", productSummaryModel);
        }

        public void GetProductTypeInfo()
        {
            Service service = new Service();
            List<tblTypeRange> typeRanges = new List<tblTypeRange>();
            Dictionary<string, string> dict = service.GetProductTypeRange("1");

            // populate tblTypeRange object with dictionary values
            foreach(KeyValuePair<string, string> keyVals in dict)
            {
                tblTypeRange currentTypeRange = new tblTypeRange();
                currentTypeRange.TypeName = keyVals.Key;
                currentTypeRange.TypeOptions = keyVals.Value;

                // add current typeRange to list
                typeRanges.Add(currentTypeRange);
            }

            // add typeRangeObj to the dynamic model
            productSummaryModel.TypeRanges = typeRanges;
        }

        public void GetTechSpecs()
        {
            Service service = new Service();
            Dictionary<string, string> techSpecs = service.GetTechSpecs();

            // add to dynamic model
            productSummaryModel.TechSpecs = techSpecs;
        }
    }
}