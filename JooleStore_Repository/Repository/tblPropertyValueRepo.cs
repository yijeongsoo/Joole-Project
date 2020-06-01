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
        List<List<string>> FindPropertyValueByProduct(int ProductId);
    }
    public class PropertyValueRepo : Repository<tblPropertyValue>, IPropertyValueRepo
    {
        JooleDataEntities db;
        public PropertyValueRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        // TODO: Implement Methods
        public List<List<string>> FindPropertyValueByProduct(int ProductId)
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
        
    }
}
