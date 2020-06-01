using JooleStore_Service;
using JooleStoreApp.Models;
using JooleStoreApp.ViewModels;
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
        public ActionResult CompareProduct(/*Product product1, Product product2*/)
        {
            CompareProductVM CompareVM = new CompareProductVM();
            ProductValuesVM ProductVM1 = new ProductValuesVM();
            ProductValuesVM ProductVM2 = new ProductValuesVM();
            Product product1 = GetProductByName(2); // Comment out after testing
            Product product2 = GetProductByName(3); // Comment out after testing
            ProductVM1.product = product1;
            ProductVM2.product = product2;
            List<tblPropertyValue> propertyValueList1 = GetAllPropertyValueById(product1.ProductId);
            List<tblPropertyValue> propertyValueList2 = GetAllPropertyValueById(product2.ProductId);
            ProductVM1.propertyValues = propertyValueList1;
            ProductVM2.propertyValues = propertyValueList2;
            // Add Property Values for both models
            // Add Manufacturer info / Subcategory info
            CompareVM.comparingProducts.Add(ProductVM1);
            CompareVM.comparingProducts.Add(ProductVM2);
            return View("CompareProduct", "CompareProduct", CompareVM);
        }
        public Product GetProductByName(int productId)
        {
            Service service = new Service();
            List<String> strList = service.FindProduct(productId);
            Product product = new Product
            {
                ProductId = Int32.Parse(strList[1]),
                ManufacturerId = Int32.Parse(strList[2]),
                SubcategoryId = Int32.Parse(strList[3]),
                ProductName = strList[4],
                ProductImage = strList[5],
                Series = strList[6],
                ModelYear = Int32.Parse(strList[7]),
                Model = strList[8]
            };
            return product;
        }
        public Manufacturer GetManufacturer(int ManufacturerId)
        {
            // TODO: IMPLEMENT
            Manufacturer manufacturer = new Manufacturer();
            return manufacturer;
        }
        public Subcategory GetSubcategory(int SubcategoryId)
        {
            // TODO: IMPLEMENT
            Subcategory subcategory = new Subcategory();
            return subcategory;
        }
        public List<Property> GetAllPropertyById(int productId)
        {
            // TODO: IMPLEMENT
            List<Property> properties = new List<Property>();
            return properties;
        }
        
        public List<tblPropertyValue> GetAllPropertyValueById(int productId)
        {
            Service service = new Service();
            List<List<String>> strListList = service.GetAllPropertyValueById(productId);
            List<tblPropertyValue> propertyValueList = new List<tblPropertyValue>();
            foreach(List<String> strList in strListList)
            {
                tblPropertyValue propertyValue = new tblPropertyValue
                {
                    PropertyId = Int32.Parse(strList[1]),
                    ProductId = Int32.Parse(strList[2]),
                    PropertyValue = strList[3]
                };
                propertyValueList.Add(propertyValue);
            }
            return propertyValueList;
        }
    }
}