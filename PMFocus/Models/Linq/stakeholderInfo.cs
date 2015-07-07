using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.Linq
{
    public class stakeholderInfo
    {
        private static PMEntities _ctx = new PMEntities();

        internal static stakeholder GetStakeholder()
        {
            return new stakeholder();
        }
    }
}