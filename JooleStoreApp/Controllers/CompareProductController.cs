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
        public ActionResult CompareProduct(int product1Id = 2, int product2Id = 3)
        {
            CompareProductVM CompareVM = new CompareProductVM();
            CompareVM.comparingProducts = new List<ProductValuesVM>();
            ProductValuesVM ProductVM1 = new ProductValuesVM();
            ProductValuesVM ProductVM2 = new ProductValuesVM();
            ProductM product1 = GetProductByName(product1Id); // Comment out after testing
            ProductM product2 = GetProductByName(product2Id); // Comment out after testing
            ProductVM1.product = product1;
            ProductVM2.product = product2;
            Manufacturer manufacturer1 = GetManufacturer(product1.ManufacturerId);
            Manufacturer manufacturer2 = GetManufacturer(product2.ManufacturerId);
            ProductVM1.manufacturer = manufacturer1;
            ProductVM2.manufacturer = manufacturer2;
            Subcategory subcategory1 = GetSubcategory(product1.SubcategoryId);
            Subcategory subcategory2 = GetSubcategory(product2.SubcategoryId);
            ProductVM1.subcategory = subcategory1;
            ProductVM2.subcategory = subcategory2;
            List<PropertyValuesVM> propertyValuesVM1 = GetAllPropertyValuePair(product1.ProductId);
            List<PropertyValuesVM> propertyValuesVM2 = GetAllPropertyValuePair(product2.ProductId);
            ProductVM1.propertyValuesVM = propertyValuesVM1;
            ProductVM2.propertyValuesVM = propertyValuesVM2;
            CompareVM.comparingProducts.Add(ProductVM1);
            CompareVM.comparingProducts.Add(ProductVM2);
            return View("CompareProduct", CompareVM);
        }

        public List<PropertyValuesVM> GetAllPropertyValuePair(int productId)
        {
            Service service = new Service();
            List<PropertyValuesVM> propertyValuesVM = new List<PropertyValuesVM>();
            List<List<List<string>>> AllPropertyValuePair = service.FindAllPropertyAndValuePair(productId);
            foreach (List<List<string>> PropertyValuePair in AllPropertyValuePair)
            {
                PropertyValuesVM PVPair = new PropertyValuesVM();
                Property property = new Property
                {
                    PropertyId = Int32.Parse(PropertyValuePair[0][1]),
                    PropertyName = PropertyValuePair[0][2],
                    isTechSpec = Boolean.Parse(PropertyValuePair[0][3]),
                    isType = Boolean.Parse(PropertyValuePair[0][4])
                };
                tblPropertyValue propertyValue = new tblPropertyValue
                {
                    PropertyId = Int32.Parse(PropertyValuePair[1][1]),
                    ProductId = Int32.Parse(PropertyValuePair[1][2]),
                    PropertyValue = PropertyValuePair[1][3]
                };
                PVPair.property = property;
                PVPair.propertyValue = propertyValue;
                propertyValuesVM.Add(PVPair);
            }
            return propertyValuesVM;

        }
        public ProductM GetProductByName(int productId)
        {
            Service service = new Service();
            List<String> strList = service.FindProduct(productId);
            ProductM product = new ProductM
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
            Service service = new Service();
            List<String> strList = service.FindManufacturer(ManufacturerId);
            Manufacturer manufacturer = new Manufacturer
            {
                ManufacturerId = Int32.Parse(strList[1]),
                ManufacturerName = strList[2],
                ManufacturerDepartment = strList[3],
                ManufacturerWeb = strList[4]
            };
            return manufacturer;
        }
        public Subcategory GetSubcategory(int SubcategoryId)
        {
            Service service = new Service();
            List<String> strList = service.FindSubcategory(SubcategoryId);
            Subcategory subcategory = new Subcategory
            {
                SubcategoryId = Int32.Parse(strList[1]),
                CategoryId = Int32.Parse(strList[2]),
                SubcategoryName = strList[3]
            };
            return subcategory;
        }
        public List<Property> GetAllPropertyByProductId(int productId)
        {
            // TODO: IMPLEMENT
            Service service = new Service();
            List<List<string>> AllPropertyList = service.GetAllPropertyByProductId(productId);
            List<Property> properties = new List<Property>();
            foreach (List<String> strList in AllPropertyList)
            {
                Property property = new Property
                {
                    PropertyId = Int32.Parse(strList[1]),
                    PropertyName = strList[2],
                    isTechSpec = Boolean.Parse(strList[3]),
                    isType = Boolean.Parse(strList[4])
                };
                properties.Add(property);
            }
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