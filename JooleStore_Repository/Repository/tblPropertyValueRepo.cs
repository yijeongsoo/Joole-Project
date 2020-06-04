using JooleStore_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface IPropertyValueRepo : IRepository<tblPropertyValue>
    {
        // TODO: Define Methods
        List<List<string>> FindAllPropertyValueByProduct(int ProductId);
        List<string> GetByProductId(int productId);

        Dictionary<string, List<Tuple<int, string, string>>> GetPropertiesOfProduct(int productId);
    }
    public class PropertyValueRepo : Repository<tblPropertyValue>, IPropertyValueRepo
    {
        JooleDataEntities db;
        public PropertyValueRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        // TODO: Implement Methods
        public List<List<string>> FindAllPropertyValueByProduct(int ProductId)
        {
            List<List<string>> AllPropertyValueList = new List<List<string>>();
            var dbList = db.tblPropertyValues.ToList();
            foreach (tblPropertyValue element in dbList)
            {
                if (element.ProductId == ProductId)
                {
                    List<string> PropertyValueList = new List<string>();
                    PropertyValueList.Add("Yes");
                    PropertyValueList.Add(element.PropertyId.ToString());
                    PropertyValueList.Add(element.ProductId.ToString());
                    PropertyValueList.Add(element.PropertyValue.ToString());
                    AllPropertyValueList.Add(PropertyValueList);
                }
            }
            return AllPropertyValueList;
        }

        public List<string> GetByProductId(int productId)
        {
            List<string> ValueList = new List<string>();
            var dbList = db.tblPropertyValues.ToList();
            foreach (tblPropertyValue element in dbList)
            {
                if (element.ProductId == productId)
                {
                    ValueList.Add("Yes");
                    ValueList.Add(element.PropertyId.ToString());
                    ValueList.Add(element.ProductId.ToString());
                    ValueList.Add(element.PropertyValue.ToString());
                }
            }
            return ValueList;
        }

        public Dictionary<string, List<Tuple<int, string, string>>> GetPropertiesOfProduct(int productId)
        {
            List<tblPropertyValue> prodProperties = db.tblPropertyValues.Where(property => property.ProductId == productId).ToList();
            List<Property> propertyNames = db.Properties.ToList();
            Dictionary<string, List<Tuple<int, string, string>>> result = new Dictionary<string, List<Tuple<int, string, string>>>();
            result["techSpec"] = new List<Tuple<int, string, string>>();
            result["type"] = new List<Tuple<int, string, string>>();
            foreach (tblPropertyValue prodProperty in prodProperties)
            {
                for(int i=0; i<propertyNames.Count(); i++)
                {
                    if(propertyNames[i].PropertyId == prodProperty.PropertyId) 
                    {
                        if(propertyNames[i].isTechSpec == true) {
                            result["techSpec"].Add(new Tuple<int, string, string>(prodProperty.PropertyId, propertyNames[i].PropertyName, prodProperty.PropertyValue));
                            break;
                        }
                        else
                        {
                            result["type"].Add(new Tuple<int, string, string>(prodProperty.PropertyId, propertyNames[i].PropertyName, prodProperty.PropertyValue));
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
