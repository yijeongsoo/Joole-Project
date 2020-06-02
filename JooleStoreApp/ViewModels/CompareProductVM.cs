using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.ViewModels
{
    public class PropertyValuesVM
    {
        public Property property { get; set; }
        public tblPropertyValue propertyValue { get; set; }
    }
    public class ProductValuesVM
    { 
        public ProductM product { get; set; }
        public Manufacturer manufacturer { get; set; }
        public Subcategory subcategory { get; set; }
        public List<PropertyValuesVM> propertyValuesVM { get; set; }
    }
    public class CompareProductVM
    {
        public List<ProductValuesVM> comparingProducts { get; set; }
    }
}