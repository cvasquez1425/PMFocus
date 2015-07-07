using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public class projSponsorLookUp
    {
        private static PMEntities _ctx = new PMEntities();

        public static List<proj_sponsor> GetSponsorFullName()
        {

            var projSponsorList = new List<proj_sponsor>();

            using (var db = new PMEntities())
            {
                (from p in db.proj_sponsor
                 orderby p.proj_sponsor_id ascending
                 select new
                 {
                     Id = p.proj_sponsor_id,
                     Name = p.full_name
                 }).ToList()
                .ForEach(f => projSponsorList.Add(new proj_sponsor
                {
                    proj_sponsor_id = f.Id,
                    full_name = f.Name
                }));
                projSponsorList.Insert(0, new proj_sponsor { proj_sponsor_id = 0, full_name = "+Add New Sponsor" });
            }
            return projSponsorList;
        }
    }
}