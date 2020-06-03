using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleStore_DAL;
using JooleStore_Repository;
using Microsoft.Win32;

namespace JooleStore_Service
{
    public class Service
    {
        public UnitOfWork unit;
        public Service() {
            unit = UnitOfWork.GetInstance();
        }

        public Dictionary<string, string> GetUser(string email)
        {
            return unit.consumer.GetUser(email);
        }

        public bool SignUpCustomer(string username, string password, string email, string imageName)
        {
            return unit.consumer.RegisterUser(username, password, email, imageName);
        }
        public bool LoginCustomer(string email, string password)
        {
            return unit.consumer.CheckCredentials(email, password);
        }

        public List<Product> getSubcategoryProducts(int SubcategoryId) 
        {
            return unit.product.getSubcategoryProducts(SubcategoryId);
        }

        public List<tblTypeRange> getFilterType(int subcategoryId) {
            return unit.typeRangeRepo.getFilterType(subcategoryId);
        }

        public List<tblTechSpecRange> getFilterTechSpec(int subcategoryId) 
        {
            return unit.techSpecRange.getTechSpecFilter(subcategoryId);
        }
        public List<string> FindProduct(int ProductId)
        {
            List<string> ProductList = unit.product.FindProduct(ProductId);
            return ProductList;
        }

        public List<string> FindManufacturer(int ManufacturerId)
        {
            List<string> ManufacturerList = unit.manufacturer.FindManufacturer(ManufacturerId);
            return ManufacturerList;
        }

        public List<string> FindSubcategory(int SubcategoryId)
        {
            List<string> SubcategoryList = unit.subcategory.FindSubcategory(SubcategoryId);
            return SubcategoryList;
        }

        public List<string> FindProperty(int PropertyId)
        {
            List<string> PropertyList = unit.property.FindProperty(PropertyId);
            return PropertyList;
        }

        public List<List<List<string>>> FindAllPropertyAndValuePair(int productId)
        {
            List<List<List<string>>> AllValuePropertyPair = new List<List<List<string>>>();
            List<List<string>> ValueLists = unit.propertyValue.FindAllPropertyValueByProduct(productId);
            foreach (List<string> ValueList in ValueLists)
            {
                List<List<string>> ValuePropertyPair = new List<List<string>>();
                List<string> PropertyList = unit.property.FindProperty(Int32.Parse(ValueList[1]));
                ValuePropertyPair.Add(PropertyList);
                ValuePropertyPair.Add(ValueList);
                AllValuePropertyPair.Add(ValuePropertyPair);
            }
            return AllValuePropertyPair;
        }

        public List<List<string>> GetAllPropertyByProductId(int productId)
        {
            List<List<string>> PropertyList = unit.property.GetAllPropertyByProductId(productId);
            return PropertyList;
        }
        public List<List<string>> GetAllPropertyValueById(int productId)
        {
            List<List<string>> PropertyValueList = unit.propertyValue.FindAllPropertyValueByProduct(productId);
            return PropertyValueList;
        }

        public List<string> GetProductDescription(string prodId)
        {
            return unit.product.GetProductDescription(prodId);
        }

        public Dictionary<string, string> GetProductTypeInfo(string prodId)
        {
            return unit.product.GetProductTypeRange(prodId);
        }

        public Dictionary<string, string> GetTechSpecs()
        {
            return unit.product.GetTechSpecs();
        }
    }
}
