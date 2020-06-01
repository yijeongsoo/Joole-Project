using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleStore_Repository;

namespace JooleStore_Service
{
    public class Service
    {
        public UnitOfWork unit;
        public Service() {
            unit = UnitOfWork.GetInstance();
        }

        public bool LoginCustomer(string email, string password)
        {
            return unit.consumer.CheckCredentials(email, password);
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
        public List<List<string>> GetAllPropertyByProductId(int productId)
        {
            List<List<string>> PropertyList = unit.property.GetAllPropertyByProductId(productId);
            return PropertyList;
        }
        public List<List<string>> GetAllPropertyValueById(int productId)
        {
            List<List<string>> PropertyValueList = unit.propertyValue.FindPropertyValueByProduct(productId);
            return PropertyValueList;
        }
    }
}
