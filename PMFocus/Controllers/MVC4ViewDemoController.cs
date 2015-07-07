using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMFocus.Controllers
{
    public class Blog
    {
        public string Name { get; set; }
        public string URL { get; set; }
    }

    public class MVC4ViewDemoController : Controller
    {
        List<Blog> topBlogs = new List<Blog>
        {
            new Blog { Name = "ScottGu", URL = "http://weblogs.asp.net/scottgu/"},
            new Blog { Name = "Jon Galloway", URL = "http://weblogs.asp.net/jgalloway"},
            new Blog { Name = "Scott Hanselman", URL = "http://www.hanselman.com/blog/"},
            new Blog { Name = "<script>alert('xss');</script>", URL = "http://www.google.com"}  // Cross Site Scripting Attacks. 
        };

        //// http://localhost:62009/MVC4ViewDemo/IndexNotStrongTyped
        public ActionResult IndexNotStrongTyped()
        {
            return View(topBlogs);
        }
        //
        // GET: /MVC4ViewDemo/

        public ActionResult Index()
        {
            return View();
        }

    }
}
