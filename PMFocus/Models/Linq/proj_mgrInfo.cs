using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.Linq
{
    public class proj_mgrInfo
    {
        private static PMEntities _ctx = new PMEntities();

        public static proj_mgr GetProj_Mgr()
        {
            return new proj_mgr
            {
                proj_mgr_first_name = string.Empty,
                proj_mgr_last_name = string.Empty,
                proj_mgr_phone = null,
                proj_mgr_gm_ext = null,
                proj_mgr_email = string.Empty,
                createdby = string.Empty,
                createddate = DateTime.Now,
                full_name = string.Empty
            };
        }
    }
}