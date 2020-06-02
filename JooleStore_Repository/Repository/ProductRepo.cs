using JooleStore_DAL;
using JooleStore_Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JooleStore_Repository
{
    public interface IProductRepo : IRepository<Product>
    {
        List<string> FindProduct(int ProductId);
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        JooleDataEntities db;
        public ProductRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        public List<string> FindProduct(int ProductId)
        {
            List<string> ProductList = new List<string>();
            var dbList = db.Products.ToList();
            foreach (Product element in dbList)
            {
                if (element.ProductId == ProductId)
                {
                    ProductList.Add("Yes");
                    ProductList.Add(element.ProductId.ToString());
                    ProductList.Add(element.ManufacturerId.ToString());
                    ProductList.Add(element.SubcategoryId.ToString());
                    ProductList.Add(element.ProductName);
                    ProductList.Add(element.ProductImage);
                    ProductList.Add(element.Series);
                    ProductList.Add(element.ModelYear.ToString());
                    ProductList.Add(element.Model);
                }
            }
                return ProductList;
        }
        // TODO: Implement Methods
    }
}