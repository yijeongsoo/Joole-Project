using JooleStore_DAL;
using System.Data.Entity;

namespace JooleStore_Repository
{
    public interface ICategoryRepo : IRepository<Category>
    {
        // TODO: Define Methods
    }
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContext context) : base(context)
        { 
        
        }
        // TODO: Implement Methods
    }
}