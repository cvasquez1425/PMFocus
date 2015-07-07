using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class stakeholderLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<stakeholder> GetStakeholderFullName()
        {
            var stakeholderList = new List<stakeholder>();

            using (var db = new PMEntities())
            {
                (from p in db.stakeholders
                 orderby p.stakeholder_id
                 select new
                 {
                     Id = p.stakeholder_id,
                     Name = p.stakeholder_full_name
                 }).ToList()
                .ForEach(f => stakeholderList.Add(new stakeholder
                {
                    stakeholder_id = f.Id,
                    stakeholder_full_name = f.Name
                }));

                //if (stakeholderList.Any() == true)
                //{
                //    stakeholderList.Insert(0, new stakeholder());
                //}
            }
            return stakeholderList;
        }
    }
}