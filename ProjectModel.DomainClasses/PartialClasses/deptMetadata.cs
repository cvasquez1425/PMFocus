using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectModel.DomainClasses
{
    public class deptMetadata
    {
        [Display(Name = "Department Description")]
        public string dept_desc { get; set; }
    }
}
