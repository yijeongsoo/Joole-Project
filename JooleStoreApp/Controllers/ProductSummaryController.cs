using JooleStore_DAL;
using JooleStore_Service;
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
            //get subcategoryid from search page
            int subcategoryId = 1;
            Service service = new Service();
            List<Product> list = service.getSubcategoryProducts(subcategoryId);
            List<ProductM> prodList = new List<ProductM>();
            foreach (Product prod in list) {
                ProductM newProd = new ProductM
                {
                    ManufacturerId = prod.ManufacturerId,
                    ProductId = prod.ProductId,
                    ProductImage = prod.ProductImage,
                    ProductName = prod.ProductName,
                    Series = prod.Series,
                    Model = prod.Model,
                    ModelYear = prod.ModelYear,
                    SubcategoryId = prod.SubcategoryId,
                };
                prodList.Add(newProd);
            }

            return View(prodList);
        }
    }
}