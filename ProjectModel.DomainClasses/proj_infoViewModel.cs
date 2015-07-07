using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PMFocus.Models.DataLayer;

namespace ProjectModel.DomainClasses
{
    public class proj_infoViewModel
    {
        public int _proj_info_id { get; set; }

        [Required(ErrorMessage = "Project Name is a required field")]
        [Display(Name = "Project Name")]
        public string _proj_name { get; set; }

        private readonly List<proj_mgr> _proj_mgr = projMgrLookUp.GetManagerFullName();
        [Display(Name = "Manager Full Name")]
        public int _proj_mgr_id { get; set; }
        public IEnumerable<SelectListItem> managerFullNameItems
        {
            get { return new SelectList(_proj_mgr, "proj_mgr_id", "full_name"); }
        }

        private readonly List<proj_sponsor> _proj_sponsor = projSponsorLookUp.GetSponsorFullName();
        [Display(Name = "Sponsor Full Name")]
        public int _proj_sponsor_id { get; set; }
        public IEnumerable<SelectListItem> sponsorFullNameItems
        {
            get { return new SelectList(_proj_sponsor, "proj_sponsor_id", "full_name"); }
        }

        [Display(Name = "Charter Approved")]
        public bool _charter { get; set; }
        //public bool _charter { get; set; }

        [Display(Name = "Scope")]
        public string _scope_definition { get; set; }

        private readonly List<dept> _dept = deptLookUp.GetDeptList();
        [Display(Name = "Department")]
        public int _dept_id { get; set; }
        public IEnumerable<SelectListItem> deptItems
        {
            get { return new SelectList(_dept, "dept_id", "dept_desc"); }
        }

        [Display(Name = "Client")]
        public string _client { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? _proj_start_date { get; set; }

        [Display(Name = "Ending Date")]
        public DateTime? _proj_end_date { get; set; }

        private readonly List<proj_status> _proj_status = statusLookUp.GetStatusList();
        [Display(Name = "Status")]
        public int _proj_status_id { get; set; }
        public IEnumerable<SelectListItem> statusItems
        {
            get { return new SelectList(_proj_status, "proj_status_id", "proj_status_desc"); }
        }

        private readonly List<proj_type> _proj_type = projectTypeLookUp.GetProjectTypeList();
        [Display(Name = "Type Of Project")]
        public int proj_type_id { get; set; }
        public IEnumerable<SelectListItem> projectTypeItems
        {
            get { return new SelectList(_proj_type, "project_type_id", "project_type_name"); }
        }

        public string _createdby { get; set; }

        public DateTime? _createddate { get; set; }

        [Display(Name = "Notes")]
        public string _notes { get; set; }

        [Required(ErrorMessage = "Project Goal is a required field")]
        [Display(Name = "Project Goal")]
        public string _proj_goal { get; set; }

        [Display(Name = "Location of PM Documents")]
        public string _doc_location { get; set; }
    }
}
