using JooleStore_DAL;
using System.Data.Entity;

namespace JooleStore_Repository
{
    public interface ITypeRangeRepo : IRepository<tblTypeRange>
    {
        // TODO: Define Methods
    }
    public class TypeRangeRepo : Repository<tblTypeRange>, ITypeRangeRepo
    {
        public TypeRangeRepo(DbContext context) : base(context)
        { 
        
        }
        // TODO: Implement Methods 
    }
}