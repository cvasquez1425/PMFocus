using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectModel.DomainClasses;

namespace ProjectModel.DomainClasses
{
    /// <summary>
    /// this proj_type class will extend the generated proj_type class.
    /// .NET will see this partial class and the other partial class prog_type and pull them together.
    /// </summary>
    [MetadataType(typeof(proj_typeMetadata))]
    public partial class proj_type
    {
    }
}
