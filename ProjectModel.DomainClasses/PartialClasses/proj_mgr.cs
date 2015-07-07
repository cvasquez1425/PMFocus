using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.DomainClasses
{
    /// <summary>
    /// this proj_mgr class will extend the generated proj_mgr class.
    /// .NET will see this partial class and the other partial class prog_mgr and pull them together.
    /// </summary>
    public partial class proj_mgr
    {
        // A Custom FullName Property to concatenate First and Last names, you can't use this in a query because fullname doesn't really map to anything in the database, but in your application code you can use it.
        public string FullName 
        { 
            get { return this.proj_mgr_last_name.Trim() + "," + this.proj_mgr_first_name ;}
//            set { FullName = value; }
        }
    }
}
