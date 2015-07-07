using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class deptLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<dept> GetDeptList()
        {

            var deptList = new List<dept>();

            using (var db = new PMEntities())
            {
                (from p in db.depts
                 orderby p.dept_id ascending
                 select new
                 {
                     Id = p.dept_id,
                     Name = p.dept_desc
                 }).ToList()
                .ForEach(f => deptList.Add(new dept
                {
                    dept_id = f.Id,
                    dept_desc = f.Name
                }));
                deptList.Insert(0, new dept { dept_id = 0, dept_desc = "+Add New Department" });
            }
            return deptList;
        }
    }
}