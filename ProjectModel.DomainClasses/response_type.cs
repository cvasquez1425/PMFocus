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
    
    public partial class response_type
    {
        public response_type()
        {
            this.risk_register = new HashSet<risk_register>();
        }
    
        public int response_type_id { get; set; }
        public string response_type_desc { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
    
        public virtual ICollection<risk_register> risk_register { get; set; }
    }
}
