//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Asp_MVC__JQuery_Ajax_.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeTable
    {
        public int EmoloyeId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual CityTable CityTable { get; set; }
    }
}
