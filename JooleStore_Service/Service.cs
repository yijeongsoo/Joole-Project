using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleStore_DAL;
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
    }
}
