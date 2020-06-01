using JooleStore_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface IPropertyRepo : IRepository<Property>
    {
        // TODO: Define Methods
        List<string> FindProperty(int PropertyId);
    }
    public class PropertyRepo : Repository<Property>, IPropertyRepo
    {
        JooleDataEntities db;
        public PropertyRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }

        public List<string> FindProperty(int PropertyId)
        {
            List<string> PropertyList = new List<string>();
            var dbList = db.Properties.ToList();
            foreach (Property element in dbList)
            {
                if (element.PropertyId == PropertyId)
                {
                    PropertyList.Add("Yes");
                    PropertyList.Add(element.PropertyId.ToString());
                    PropertyList.Add(element.PropertyName.ToString());
                    PropertyList.Add(element.isTechSpec.ToString());
                    PropertyList.Add(element.isType.ToString());
                }
                else
                {
                    PropertyList.Add("No");
                }
            }
            return PropertyList;
        }
        // TODO: Implement Methods
        // TODO: Implement find all prop by prodID
    }
}
