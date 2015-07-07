using System.Web;
using System.Web.Mvc;

namespace PMFocus
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // global filter like HandleErrorAttribute will be in effect for every single request that is processed by any controller inside your application
            // and the purpose of the handle error attribute is to display a friendly error page to users when something goes wrong.
            filters.Add(new HandleErrorAttribute()); 
        }
    }
}