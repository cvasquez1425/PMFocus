using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectModel.DomainClasses
{
    public class proj_logViewModel
    {
        public int _proj_log_id { get; set; }
        public int _proj_info_id { get; set; }
        public int _proj_log_code_id { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string _action_from { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public string _action_to { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(500)]
        public string _comments { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(10)]
        public string _createdby { get; set; }

        public DateTime _createddate { get; set; }

        public DateTime? _action_date_from { get; set; }
        public DateTime? _action_date_to { get; set; }
    }
}
