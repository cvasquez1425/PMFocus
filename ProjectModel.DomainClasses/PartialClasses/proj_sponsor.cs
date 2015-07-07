using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.DomainClasses
{
    /// <summary>
    /// this proj_sponsor class will extend the generated proj_sponsor class.
    /// .NET will see this partial class and the other partial class prog_sponsor and pull them together.
    /// </summary>
    public partial class proj_sponsor
    {
        public string fullNameSponsor
        {

            get { return this.proj_sponsor_last_name.Trim() + "," + this.proj_sponsor_first_name; }
        }
    }
}
