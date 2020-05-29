using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleStoreApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public int ManufacturerId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> DepartmentPhone { get; set; }
        public string DepartmentEmail { get; set; }
    }
}