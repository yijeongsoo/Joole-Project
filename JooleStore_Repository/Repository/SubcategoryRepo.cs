using JooleStore_DAL;
using JooleStore_Repository.Repository;
using System.Data.Entity;

namespace JooleStore_Repository
{
    public interface ISubcategoryRepo : IRepository<Subcategory>
    {
        // TODO: Define the methods
    }
    public class SubcategoryRepo : Repository<Subcategory>, ISubcategoryRepo
    {
        public SubcategoryRepo(DbContext context) : base(context)
        { 
        
        }
        // TODO: Implement Methods
    }
}