using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class SearchResultViewModel
    {
        public List<ProductM> Products { get; set; }
        public List<tblTechSpecRangeM> TechSpecFilterList { get; set; }
        public List<tblTypeRangeM> TypeRangeFilterList { get; set; }
    }
}