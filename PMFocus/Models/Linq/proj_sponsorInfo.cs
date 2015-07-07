using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.Linq
{
    public class proj_sponsorInfo
    {
        private static PMEntities _ctx = new PMEntities();

        public string _username;
        public proj_sponsorInfo(string username)
        {
            _username = username;
        }

        public static proj_sponsor GetProj_Sponsor()
        {
            return new proj_sponsor
            {
                proj_sponsor_first_name = string.Empty,
                proj_sponsor_last_name = string.Empty,
                proj_sponsor_phone = null,
                proj_sponsor_gm_ext = null,
                proj_sponsor_email = string.Empty,
                createdby = string.Empty,
                createddate = DateTime.Now,
                full_name = string.Empty
            };
        }
    }
}