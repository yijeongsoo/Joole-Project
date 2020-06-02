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
        bool RegisterUser(string username, string password, string email, string imageName);
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
                if (element.UserEmail.ToString() == email && element.UserPassword.ToString() == password)
                {
                    confirmLogin = true;
                }
            }
            return confirmLogin;
        }

        public bool RegisterUser(string username, string password, string email, string imageName)
        {
            var dbList = db.Users.ToList();

            foreach (User element in dbList)
            {
                if (element.UserEmail.ToString() == email && element.UserPassword.ToString() == password)
                {
                    return false;
                }
            }

            db.Users.Add(new User { UserName = username, UserPassword = password, UserEmail = email, UserImage = imageName });
            db.SaveChanges();

            return true;
        }
    }
}