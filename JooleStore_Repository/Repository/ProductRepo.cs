using JooleStore_DAL;
using JooleStore_Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JooleStore_Repository
{
    public interface IProductRepo : IRepository<Product>
    {
        // TODO: Define Methods
        List<Product> getSubcategoryProducts(int SubcategoryId);
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        JooleDataEntities db;
        public ProductRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }

        public List<Product> getSubcategoryProducts(int SubcategoryId)
        {
            List<Product> orders = db.Products.Where(product => product.SubcategoryId == SubcategoryId).ToList();
            return orders;
        }
       
    }
}