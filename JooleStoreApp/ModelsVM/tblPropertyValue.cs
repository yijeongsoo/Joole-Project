//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleStoreApp.ModelsVM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPropertyValue
    {
        public int PropertyId { get; set; }
        public int ProductId { get; set; }
        public int PropertyValue { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
    }
}
