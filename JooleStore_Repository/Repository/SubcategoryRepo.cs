using JooleStore_DAL;
using JooleStore_Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JooleStore_Repository
{
    public interface ISubcategoryRepo : IRepository<Subcategory>
    {
        // TODO: Define the methods
        List<string> FindSubcategory(int SubcategoryId);
    }
    public class SubcategoryRepo : Repository<Subcategory>, ISubcategoryRepo
    {
        JooleDataEntities db;
        public SubcategoryRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        // TODO: Implement Methods
        public List<string> FindSubcategory(int SubcategoryId)
        {
            List<string> SubcategoryList = new List<string>();
            var dbList = db.Subcategories.ToList();
            foreach (Subcategory element in dbList)
            {
                if (element.SubcategoryId == SubcategoryId)
                {
                    SubcategoryList.Add("Yes");
                    SubcategoryList.Add(element.SubcategoryId.ToString());
                    SubcategoryList.Add(element.CategoryId.ToString());
                    SubcategoryList.Add(element.SubcategoryName);
                }
            }
            return SubcategoryList;
        }
        
    }
}