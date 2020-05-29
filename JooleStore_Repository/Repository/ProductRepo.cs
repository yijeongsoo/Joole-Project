using JooleStore_DAL;
using JooleStore_Repository;
using System.Data.Entity;

namespace JooleStore_Repository
{
    public interface IProductRepo : IRepository<Product>
    {
        // TODO: Define Methods
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}