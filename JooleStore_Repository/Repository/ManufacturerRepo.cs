using JooleStore_DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface IManufacturerRepo : IRepository<Manufacturer>
    {
        // TODO: Define Methods
        List<string> FindManufacturer(int ManufacturerId);
    }
    public class ManufacturerRepo : Repository<Manufacturer>, IManufacturerRepo
    {
        JooleDataEntities db;
        public ManufacturerRepo(JooleDataEntities context) : base(context)
        {
            db = context;
        }
        // TODO: Implement Methods
        // TODO: Find Manufacturer
        public List<string> FindManufacturer(int ManufacturerId)
        {
            List<string> ManufacturerList = new List<string>();
            var dbList = db.Manufacturers.ToList();
            foreach (Manufacturer element in dbList)
            {
                if (element.ManufacturerId == ManufacturerId)
                {
                    ManufacturerList.Add("Yes");
                    ManufacturerList.Add(element.ManufacturerId.ToString());
                    ManufacturerList.Add(element.ManufacturerName.ToString());
                    ManufacturerList.Add(element.ManufacturerDepartment.ToString());
                    ManufacturerList.Add(element.ManufacturerWeb.ToString());
                }
                else
                {
                    ManufacturerList.Add("No");
                }
            }
            return ManufacturerList;
        }
    }
}