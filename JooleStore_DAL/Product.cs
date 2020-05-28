//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleStore_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.tblPropertyValues = new HashSet<tblPropertyValue>();
        }
    
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public int SubcategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Series { get; set; }
        public int ModelYear { get; set; }
        public string Model { get; set; }
    
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPropertyValue> tblPropertyValues { get; set; }
    }
}
