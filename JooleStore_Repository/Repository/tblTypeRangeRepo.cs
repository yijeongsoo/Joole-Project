using JooleStore_DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JooleStore_Repository
{
    public interface ITypeRangeRepo : IRepository<tblTypeRange>
    {
        List<tblTypeRange> getFilterType(int subcategoryId);
    }
    public class TypeRangeRepo : Repository<tblTypeRange>, ITypeRangeRepo
    {
        JooleDataEntities db;
        public TypeRangeRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }

        public List<tblTypeRange> getFilterType(int subcategoryId)
        {
            List<tblTypeRange> filterTypes = db.tblTypeRanges.Where(filterType => filterType.SubcategoryId == subcategoryId).ToList();
            return filterTypes;
        }
    }
}