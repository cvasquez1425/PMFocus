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
    
    public partial class closing
    {
        public int proj_close_id { get; set; }
        public bool final_reports_run { get; set; }
        public bool product_delivered { get; set; }
        public bool contracts_closed { get; set; }
        public bool project_team_released { get; set; }
        public string lessons_learned { get; set; }
        public int proj_info_id { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
        public bool sponsor_approval { get; set; }
        public string notes { get; set; }
    
        public virtual proj_info proj_info { get; set; }
    }
}
