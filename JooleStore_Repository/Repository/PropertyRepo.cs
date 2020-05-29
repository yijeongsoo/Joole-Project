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
    }
    public class PropertyRepo : Repository<Property>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}
