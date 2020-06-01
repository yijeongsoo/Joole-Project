using JooleStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.ViewModels
{
    public class ProductValuesVM
    { 
        public Product product { get; set; }
        public Manufacturer manufacturer { get; set; }
        public Subcategory subcategory { get; set; }
        public List<Property> properties { get; set; }
        public List<tblPropertyValue> propertyValues { get; set; }
    }
    public class CompareProductVM
    {
        public ProductValuesVM productValue { get; set; }
        public List<ProductValuesVM> comparingProducts { get; set; }
    }
}