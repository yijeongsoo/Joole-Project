﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class ProductM
    {
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public int SubcategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Series { get; set; }
        public int ModelYear { get; set; }
        public string Model { get; set; }

        public List<PropertyViewM> techSpec { get; set; }
        public List<PropertyViewM> typeProp { get; set; }

    }

    public class PropertyViewM 
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
    }
}