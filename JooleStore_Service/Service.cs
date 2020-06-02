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

        public bool SignUpCustomer(string username, string password, string email, string imageName)
        {
            return unit.consumer.RegisterUser(username, password, email, imageName);
        }
        public bool LoginCustomer(string email, string password)
        {
            return unit.consumer.CheckCredentials(email, password);
        }
    }
}
