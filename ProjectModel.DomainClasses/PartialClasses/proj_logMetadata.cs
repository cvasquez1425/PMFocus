using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using PMFocus.Models.DataLayer;

namespace ProjectModel.DomainClasses
{
    public class proj_logMetadata
    {
        public int proj_log_id { get; set; }
        public int proj_info_id { get; set; }

        private readonly List<proj_log_code> _proj_log_code = projLogCode.GetProjectLogCodeDescription();
        [Display(Name = "Project Code Description")]
        public int proj_log_code_id { get; set; }
        public IEnumerable<SelectListItem> projectLogCodeItems
        {
            get { return new SelectList(_proj_log_code, "proj_log_code_id", "proj_log_code_desc"); }
        }

        [Display(Name = "Action From")]
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string action_from { get; set; }

        [Display(Name = "Action To")]
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string action_to { get; set; }

        [Display(Name = "Comments")]
        public string comments { get; set; }

        [Display(Name = "Created By")]
        public string createdby { get; set; }

        [Display(Name = "Created Date")]
        public System.DateTime createddate { get; set; }

        [Display(Name = "Action Date From")]
        public Nullable<System.DateTime> action_date_from { get; set; }

        [Display(Name = "Action Date To")]
        public Nullable<System.DateTime> action_date_to { get; set; }
    }
}
