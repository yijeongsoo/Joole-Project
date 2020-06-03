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

        public List<string> GetProductDescription(string prodId)
        {
            return unit.product.GetProductDescription(prodId);
        }

        public Dictionary<string, string> GetProductTypeRange(string prodId)
        {
            return unit.product.GetProductTypeRange(prodId);
        }

        public Dictionary<string, string> GetTechSpecs()
        {
            return unit.product.GetTechSpecs();
        }
    }
}
