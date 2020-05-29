using JooleStore_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface ITechSpecRangeRepo : IRepository<tblTechSpecRange>
    {
        // TODO: Define Methods
    }
    public class TechSpecRangeRepo : Repository<tblTechSpecRange>, ITechSpecRangeRepo
    {
        public TechSpecRangeRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}
