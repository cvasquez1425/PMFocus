using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectModel.DomainClasses
{
    public class proj_typeMetadata
    {
        [Display(Name = "Type of Project")]
        public string project_type_name { get; set; }
    }
}
