using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.Linq
{
    public class projectInfoNew
    {
        private static PMEntities _ctx = new PMEntities();

        public static proj_info GetProjectInfo()
        {
            return new proj_info();
        }

        public static proj_infoViewModel GetProj_infoViewModel()
        {
            return new proj_infoViewModel();
        }
    }
}
