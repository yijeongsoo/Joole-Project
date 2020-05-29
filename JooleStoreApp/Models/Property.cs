using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public bool isTechSpec { get; set; }
        public bool isType { get; set; }
    }
}