using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleStore_DAL;

namespace JooleStore_Repository
{
    public class UnitOfWork : IDisposable
    {
        JooleDataEntities Context;
        public IConsumerRepo consumer;
        public ITypeRangeRepo typeRangeRepo;
        public ISubcategoryRepo subcategory;
        public ICategoryRepo category;
        public IManufacturerRepo manufacturer;
        public IProductRepo product;
        public IDepartmentRepo department;
        public ITechSpecRangeRepo techSpecRange;
        public IPropertyRepo property;
        public IPropertyValueRepo propertyValue;

        private UnitOfWork() {
            Context = new JooleDataEntities();
            consumer = new ConsumerRepo(Context);
            typeRangeRepo = new TypeRangeRepo(Context);
            subcategory = new SubcategoryRepo(Context);
            category = new CategoryRepo(Context);
            manufacturer = new ManufacturerRepo(Context);
            product = new ProductRepo(Context);
            techSpecRange = new TechSpecRangeRepo(Context);
            department = new DepartmentRepo(Context);
            property = new PropertyRepo(Context);
            propertyValue = new PropertyValueRepo(Context);
        }

        // Singleton Approach
        public static UnitOfWork obj;
        public static UnitOfWork GetInstance() {
            if (obj == null)
            {
                obj = new UnitOfWork();
            }
            return obj;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
