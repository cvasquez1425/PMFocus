//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectModel.DomainClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class proj_cost
    {
        public int proj_cost_id { get; set; }
        public int cost_id { get; set; }
        public int proj_info_id { get; set; }
        public decimal amount { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
    
        public virtual cost cost { get; set; }
        public virtual proj_info proj_info { get; set; }
    }
}
