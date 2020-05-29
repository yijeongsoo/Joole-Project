using System.Data.Entity;
using JooleStore_DAL;
using System.Linq;
using System.Collections.Generic;

namespace JooleStore_Repository
{
    public interface IConsumerRepo : IRepository<User>
    {
        // TODO: Define the methods
        bool CheckCredentials(string email, string password);
    }
    public class ConsumerRepo : Repository<User>, IConsumerRepo
    {
        JooleDataEntities db;
        public ConsumerRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        // TODO: Implement Methods.
        public bool CheckCredentials(string email, string password)
        {
            bool confirmLogin = false;
            var dbList = db.Users.ToList();

            foreach (User element in dbList) {
                if (element.UserEmail == email && element.UserPassword == password)
                {
                    confirmLogin = true;
                }
            }
            return confirmLogin;
        }
        
    }
}