using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class projMgrLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<proj_mgr> GetManagerFullName()
        {

            var projManagerList = new List<proj_mgr>();

            using (var db = new PMEntities())
            {
                (from p in db.proj_mgr
                 orderby p.proj_mgr_id ascending
                 select new
                 {
                     Id = p.proj_mgr_id,
                     Name = p.full_name
                 }).ToList()
                .ForEach(f => projManagerList.Add(new proj_mgr
                {
                    proj_mgr_id = f.Id,
                    full_name = f.Name
                }));
                projManagerList.Insert(0, new proj_mgr { proj_mgr_id = 0, full_name = "+Add New Manager"});
            }
            return projManagerList;
        }
    }
}