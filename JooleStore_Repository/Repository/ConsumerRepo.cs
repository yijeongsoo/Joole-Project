using System.Data.Entity;
using JooleStore_DAL;
using System.Linq;
using System.Collections.Generic;

namespace JooleStore_Repository
{
    public interface IConsumerRepo : IRepository<User>
    {
        // TODO: Define the methods
        Dictionary<string, string> GetUser(string email);
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

        public Dictionary<string, string> GetUser(string email)
        {
            var dbList = db.Users.ToList();

            foreach (User element in dbList)
            {
                if (element.UserEmail.ToString() == email || element.UserName == email)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("UserName", element.UserName);
                    dict.Add("UserEmail", element.UserEmail);
                    dict.Add("UserPassword", element.UserPassword);
                    dict.Add("UserImage", element.UserImage);

                    return dict;
                }
            }

            return null;
        }
        public bool CheckCredentials(string email, string password)
        {
            bool confirmLogin = false;
            var dbList = db.Users.ToList();

            foreach (User element in dbList) {
                if ((element.UserEmail.ToString() == email || element.UserName == email) && element.UserPassword.ToString() == password)
                {
                    confirmLogin = true;
                    break;
                }
            }
            return confirmLogin;
        }
        
        public bool RegisterUser(string username, string password, string email, string imageName)
        {
            var dbList = db.Users.ToList();

            foreach (User element in dbList)
            {
                if ((element.UserEmail.ToString() == email || element.UserName == email)&& element.UserPassword.ToString() == password)
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