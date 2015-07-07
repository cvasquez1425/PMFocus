using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class projectTypeLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<proj_type> GetProjectTypeList()
        {
            var projectTypeList = new List<proj_type>();

            using (var db = new PMEntities())
            {
                (from p in db.proj_type
                 orderby p.project_type_id ascending
                 select new
                 {
                     Id = p.project_type_id,
                     Name = p.project_type_name
                 }).ToList()
                .ForEach(f => projectTypeList.Add(new proj_type
                {
                    project_type_id = f.Id,
                    project_type_name = f.Name
                }));
            }
            return projectTypeList;
        }
    }
}