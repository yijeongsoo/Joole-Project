using JooleStore_DAL;
using JooleStore_Service;
using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
            //GetProductSummary(3);
            return View("ProductSummary");
        }

        [HttpGet]
        public ActionResult GetProductSummary(int prodId)
        {
            System.Diagnostics.Debug.WriteLine("Called function from controller. ID is: ");
            //string id = prodId.ToString();
            // string id = RouteData.Values["prodId"].ToString();
            string id = prodId.ToString();
            System.Diagnostics.Debug.WriteLine("Retrieved id: " + RouteData.Values["prodId"]);

            Service service = new Service();
            List<string> descriptionElements = service.GetProductDescription(id);

            // create a product model to generate description table
            ProductM prod = new ProductM();

            // list order: name, series, model, model year
            prod.ProductName = descriptionElements[0];
            prod.Series = descriptionElements[1];
            prod.Model = descriptionElements[2];
            prod.ModelYear = int.Parse(descriptionElements[3]);

            /* add product to a list
               depiste having one object only, we need to create a list in order for the dynamic model
               and table rendering to work properly */
            List<ProductM> prodList = new List<ProductM>();
            prodList.Add(prod);

            // add add the above list to the dynamic model
            productSummaryModel.Products = prodList;

            // get product type info
            GetProductTypeInfo(id);

            // get tech specs
            GetTechSpecs();

            //return RedirectToAction("Index", "ProductSummary", productSummaryModel);
            return View("ProductSummary", productSummaryModel);
        }

        public void GetProductTypeInfo(string id)
        {
            Service service = new Service();
            //List<tblPropertyValue> typeRanges = new List<tblPropertyValue>();
            Dictionary<string, string> dict = service.GetProductTypeInfo(id);

            // create a Dictionary of tblPropertyValue and Property to populate the UI
            Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();

            // populate tblTypeRange object with dictionary values
            foreach(KeyValuePair<string, string> keyVals in dict)
            {
                PropertyM currentPropertyName = new PropertyM();
                currentPropertyName.PropertyName = keyVals.Key;

                tblPropertyValueM currentPropValue = new tblPropertyValueM();
                currentPropValue.PropertyValue = keyVals.Value;

                // add both to property dictionary
                propertyDictionary.Add(currentPropertyName.PropertyName, currentPropValue.PropertyValue);
            }

            // add dictionary to the dynamic model
            productSummaryModel.ProductTypes = propertyDictionary;
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