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
        Dictionary<string, string> GetProductTypeRange(string prodId);
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
                descriptionElements.Add(prod.ModelYear.ToString());
            }

            System.Diagnostics.Debug.WriteLine("Generated list: ");
            foreach(string element in descriptionElements)
            {
                System.Diagnostics.Debug.WriteLine(element);
            }

            // TODO: return descriptionElements
            return descriptionElements;
        }

        public Dictionary<string, string> GetProductTypeRange(string id)
        {
            int parsedId = int.Parse(id);
            Dictionary<string, string> typeRangeElements = new Dictionary<string, string>();

            var queryResult = from prop in db.Properties
                              join propval in db.tblPropertyValues on prop.PropertyId equals propval.PropertyId
                              where propval.ProductId == 1
                              select new { PropertyName = prop.PropertyName, PropertyValue = propval.PropertyValue };


            foreach(var result in queryResult)
            {
                System.Diagnostics.Debug.WriteLine("PV: " + result.PropertyName + " : " +
                                                    result.PropertyValue);

                typeRangeElements.Add(result.PropertyName, result.PropertyValue);
            }

            return typeRangeElements;
        }

        // TODO: Implement Methods
    }
}