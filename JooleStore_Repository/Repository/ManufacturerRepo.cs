using JooleStore_DAL;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface IManufacturerRepo : IRepository<Manufacturer>
    {
        // TODO: Define Methods
    }
    public class ManufacturerRepo : Repository<Manufacturer>, IManufacturerRepo
    {
        public ManufacturerRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}