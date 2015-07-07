using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class projLogCode
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<proj_log_code> GetProjectLogCodeDescription()
        {

            var projcodedescList = new List<proj_log_code>();

            using (var db = new PMEntities())
            {
                (from p in db.proj_log_code
                 orderby p.proj_log_code_id ascending
                 where p.is_auto == false
                 select new
                 {
                     Id = p.proj_log_code_id,
                     Name = p.proj_log_code_desc
                 }).ToList()
                .ForEach(f => projcodedescList.Add(new proj_log_code
                {
                    proj_log_code_id = f.Id,
                    proj_log_code_desc = f.Name
                }));
            }
            return projcodedescList;
        }
    }
}