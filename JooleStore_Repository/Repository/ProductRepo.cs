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
        List<string> GetProductDescription(string id);
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        JooleDataEntities db;
        public ProductRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }

        public List<string> GetProductDescription(string id)
        {
            int parsedId = int.Parse(id);
            List<string> descriptionElements = new List<string>();
            var products = db.Products.Where(p => p.ProductId == parsedId);

            foreach(Product prod in products)
            {
                descriptionElements.Add(prod.ProductName);
                descriptionElements.Add(prod.Series);
                descriptionElements.Add(prod.Model);
            }

            System.Diagnostics.Debug.WriteLine("Generated list: ");
            foreach(string element in descriptionElements)
            {
                System.Diagnostics.Debug.WriteLine(element);
            }

            // TODO: return descriptionElements
            return descriptionElements;
        }
        // TODO: Implement Methods
    }
}