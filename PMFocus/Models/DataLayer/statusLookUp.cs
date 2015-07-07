using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class statusLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<proj_status> GetStatusList()
        {
            var statusList = new List<proj_status>();

            using (var db = new PMEntities())
            {
                (from p in db.proj_status
                 orderby p.proj_status_id ascending
                 select new
                 {
                     Id = p.proj_status_id,
                     Name = p.proj_status_desc
                 }).ToList()
                .ForEach(f => statusList.Add(new proj_status
                {
                    proj_status_id = f.Id,
                    proj_status_desc = f.Name
                }));
            }
            return statusList;
        }
    }
}