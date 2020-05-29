using JooleStore_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleStore_Repository
{
    public interface IDepartmentRepo : IRepository<Department>
    {
        // TODO: Define Methods
    }
    public class DepartmentRepo : Repository<Department>, IDepartmentRepo
    {
        public DepartmentRepo(DbContext context) : base(context)
        {

        }
        // TODO: Implement Methods
    }
}
