using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class tblTypeRangeM
    {
        public int PropertyId { get; set; }
        public int SubcategoryId { get; set; }
        public string TypeName { get; set; }
        public string[] TypeOptions { get; set; }
    }
}