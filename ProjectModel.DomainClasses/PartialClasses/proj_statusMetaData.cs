using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectModel.DomainClasses
{
    public class proj_statusMetaData
    {
        [Display(Name = "Project Status")]
        public string proj_status_desc { get; set; }
    }
}
