using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class tblTechSpecRangeM
    {
        public int PropertyId { get; set; }
        public int SubcategoryId { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string PropertyName { get; set; }
    }
}