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
    
    public partial class risk_objective
    {
        public risk_objective()
        {
            this.risk_register = new HashSet<risk_register>();
        }
    
        public int risk_objective_id { get; set; }
        public string risk_objective_desc { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
    
        public virtual ICollection<risk_register> risk_register { get; set; }
    }
}
