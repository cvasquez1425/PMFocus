using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HibernatingRhinos.Profiler.Appender;
using System.Web.WebPages;

namespace PMFocus
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Display Modes are extremenly useful in any scenario where multiple views for the same action can be selected based on run-time conditions.
            // CODE Magazine.

            //var tablet = new DefaultDisplayMode("tablet")
            //{
            //    ContextCondition = (c =>  IsTablet (c.Request))
            //};
            //var desktop = new DefaultDisplayMode("desktop")
            //{
            //    ContextCondition = (c => return true)
            //};
            //displayModes.Clear();
            //displayModes.Add(tablet);
            //displayModes.Add(desktop);
        }
    }
}