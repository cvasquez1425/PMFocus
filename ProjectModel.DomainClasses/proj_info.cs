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
    
    public partial class proj_info
    {
        public proj_info()
        {
            this.closings = new HashSet<closing>();
            this.proj_cost = new HashSet<proj_cost>();
            this.proj_stakeholder = new HashSet<proj_stakeholder>();
            this.proj_wbs = new HashSet<proj_wbs>();
            this.risk_register = new HashSet<risk_register>();
            this.proj_log = new HashSet<proj_log>();
            this.proj_issues = new HashSet<proj_issues>();
        }
    
        public int proj_info_id { get; set; }
        public string proj_name { get; set; }
        public int proj_mgr_id { get; set; }
        public int proj_sponsor_id { get; set; }
        public Nullable<bool> charter { get; set; }
        public string scope_definition { get; set; }
        public Nullable<int> dept_id { get; set; }
        public string client { get; set; }
        public System.DateTime proj_start_date { get; set; }
        public Nullable<System.DateTime> proj_end_date { get; set; }
        public int proj_status_id { get; set; }
        public int project_type_id { get; set; }
        public string createdby { get; set; }
        public System.DateTime createddate { get; set; }
        public string notes { get; set; }
        public string proj_goal { get; set; }
        public string doc_location { get; set; }
    
        public virtual ICollection<closing> closings { get; set; }
        public virtual dept dept { get; set; }
        public virtual ICollection<proj_cost> proj_cost { get; set; }
        public virtual proj_info proj_info1 { get; set; }
        public virtual proj_info proj_info2 { get; set; }
        public virtual proj_mgr proj_mgr { get; set; }
        public virtual proj_sponsor proj_sponsor { get; set; }
        public virtual proj_status proj_status { get; set; }
        public virtual proj_type proj_type { get; set; }
        public virtual ICollection<proj_stakeholder> proj_stakeholder { get; set; }
        public virtual ICollection<proj_wbs> proj_wbs { get; set; }
        public virtual ICollection<risk_register> risk_register { get; set; }
        public virtual ICollection<proj_log> proj_log { get; set; }
        public virtual ICollection<proj_issues> proj_issues { get; set; }
    }
}
