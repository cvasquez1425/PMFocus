using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using ProjectManagement.DataLayer;
using System.Web.Mvc;
using PMFocus.Models.DataLayer;

namespace ProjectModel.DomainClasses
{
    public class stakeholderViewModel
    {
        public int _proj_info_id { get; set; }

        private readonly List<stakeholder> _stakeholder = stakeholderLookUp.GetStakeholderFullName();
        [Display(Name = "StakeHolder")]
        public int _stakeholder_id { get; set; }
        public IEnumerable<SelectListItem> stakeholderFullNameItems
        {
            get { return new SelectList(_stakeholder, "stakeholder_id", "stakeholder_full_name"); }
        }
        
        [Display(Name = "First Name")]
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string _stakeholder_first_name { get; set; }

        [Display(Name = "Last Name")]
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string _stakeholder_last_name { get; set; }

        [Display(Name= "Phone Number")]
        [Column(TypeName = "VARCHAR"), MaxLength(15)]
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}",
                    ErrorMessage = "Invalid phone number.")]
        public string _stakeholder_phone { get; set; }

        [Display(Name= "Extension")]
        public int? _stakeholder_gm_ext { get; set; }

        [Display(Name = "Email Address")]
        [Column(TypeName = "VARCHAR"), MaxLength(50)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", 
            ErrorMessage = "Invalid email address.")]
        public string _stakeholder_email { get; set; }

        [Display(Name = "Notes")]
        [Column(TypeName = "VARCHAR"), MaxLength(200)]
        public string _notes { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(10)]
        public string _createdby { get; set; }

        public DateTime? _createddate { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(41)]
        public string _stakeholder_full_name { get; set; }
    }
}
