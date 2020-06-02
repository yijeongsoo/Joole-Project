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
        List<tblTechSpecRange> getTechSpecFilter(int subcategoryId);
    }
    public class TechSpecRangeRepo : Repository<tblTechSpecRange>, ITechSpecRangeRepo
    {
        JooleDataEntities db;
        public TechSpecRangeRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }

        public List<tblTechSpecRange> getTechSpecFilter(int subcategoryId)
        {
            List<tblTechSpecRange> queryResult = db.tblTechSpecRanges.Where(specRange => specRange.SubcategoryId == subcategoryId).ToList();
            return queryResult;
        }
        
    }
}
