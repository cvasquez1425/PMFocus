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
    
    public partial class proj_log
    {
        public int proj_log_id { get; set; }
        public int proj_info_id { get; set; }
        public int proj_log_code_id { get; set; }
        public string action_from { get; set; }
        public string action_to { get; set; }
        public string comments { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
        public Nullable<System.DateTime> action_date_from { get; set; }
        public Nullable<System.DateTime> action_date_to { get; set; }
    
        public virtual proj_info proj_info { get; set; }
        public virtual proj_log_code proj_log_code { get; set; }
    }
}
