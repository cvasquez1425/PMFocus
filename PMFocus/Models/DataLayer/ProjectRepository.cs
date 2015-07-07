using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMFocus;
using ProjectModel.DomainClasses;

namespace PMFocus.Models.DataLayer
{
    public static class ProjectRepository
    {
        public static PMEntities _ctx = new PMEntities();

        public static PMEntities CreateContext()
        {
            return new PMEntities();
        }
    }
}