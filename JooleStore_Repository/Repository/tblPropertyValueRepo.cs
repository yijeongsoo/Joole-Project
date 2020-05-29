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
    }
    public class PropertyValueRepo : Repository<tblPropertyValue>, IPropertyValueRepo
    {
        public PropertyValueRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}
