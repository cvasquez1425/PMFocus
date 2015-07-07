using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectModel.DomainClasses
{
    public class stakeholderMetadata
    {
        [Display(Name = "StakeHolder")]
        public int stakeholder_id { get; set; }
    }
}
