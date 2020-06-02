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
        List<List<string>> GetAllPropertyByProductId(int ProductId);
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
            }
            return PropertyList;
        }
        // TODO: Implement Methods
        public List<List<string>> GetAllPropertyByProductId(int ProductId) {
            List<List<string>> AllPropertyList = new List<List<string>>();
            var dbPropertyList = db.Properties.ToList();
            var dbPropertyValueList = db.tblPropertyValues.ToList();
            foreach (tblPropertyValue PVElement in dbPropertyValueList)
            {
                if (PVElement.ProductId == ProductId)
                {
                    foreach (Property PElement in dbPropertyList)
                    {
                        if (PElement.PropertyId == PVElement.PropertyId)
                        {
                            List<string> PropertyList = new List<string>();
                            PropertyList.Add("Yes");
                            PropertyList.Add(PElement.PropertyId.ToString());
                            PropertyList.Add(PElement.PropertyName);
                            PropertyList.Add(PElement.isTechSpec.ToString());
                            PropertyList.Add(PElement.isType.ToString());
                            AllPropertyList.Add(PropertyList);
                        }
                    }
                }
            }
            return AllPropertyList;
        }
    }
}
