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
        Dictionary<string, string> GetTechSpecs();
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        JooleDataEntities db;

        /* TODO: might need to refactor this. For right now, we are keeping a list of the tech specs
           (populated when GetProductTypeRange finds a tech spech). This can be retrieved after getting
           the product type ranges
        */
        Dictionary<string, string> techSpecs = new Dictionary<string, string>();

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
            // clear any previous results added to the techspec dictionary
            techSpecs.Clear();

            int parsedId = int.Parse(id);
            Dictionary<string, string> typeRangeElements = new Dictionary<string, string>();

            var queryResult = from prop in db.Properties
                              join propval in db.tblPropertyValues on prop.PropertyId equals propval.PropertyId
                              where propval.ProductId == parsedId
                              select new { PropertyName = prop.PropertyName, PropertyValue = propval.PropertyValue,
                                           IsTechSpech = prop.isTechSpec };


            foreach(var result in queryResult)
            {
                System.Diagnostics.Debug.WriteLine("PV: " + result.PropertyName + " : " +
                                                    result.PropertyValue);

                // add to tech spec list if needed
                if(result.IsTechSpech)
                    techSpecs.Add(result.PropertyName, result.PropertyValue);
                else
                    typeRangeElements.Add(result.PropertyName, result.PropertyValue);
            }

            return typeRangeElements;
        }

        public Dictionary<string, string> GetTechSpecs()
        {
            return techSpecs;
        }

        // TODO: Implement Methods
    }
}