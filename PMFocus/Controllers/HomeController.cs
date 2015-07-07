using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjectModel.DomainClasses;
using PMFocus.Models.Linq;
using System.Reflection;

namespace PMFocus.Controllers
{
    public class HomeController : Controller
    {
        private static PMEntities _ctx = new PMEntities();

        // Display Stakeholder Grid View to Select Project Name
        public ActionResult searchStakeholder(string searchTerm)
        {
            int searchterm = int.Parse(searchTerm);
            var resultStakeholder = from p in _ctx.proj_info
                                    join pst in _ctx.proj_stakeholder on p.proj_info_id equals pst.proj_info_id
                                    where pst.stakeholder_id == searchterm
                                    select p;
//            return Content(searchTerm);
            var viewdata =
                            _ctx.stakeholders.Where(s => s.stakeholder_id == searchterm)
                            .Select(s => new
                                {
                                    s.stakeholder_full_name
                                }).Single();

            ViewData["byStakeholder"] = viewdata.stakeholder_full_name;
            return PartialView("_searchStakeholder", resultStakeholder);
        }

        // Display Department Grid View to Select Project Name
        public ActionResult searchDepartment(string searchTerm)
        {
            var resultDepartment = from p in _ctx.proj_info
                                   .Include("dept")
                                   .Where(p => p.dept.dept_desc.Contains(searchTerm))
                                   select p;

            ViewData["byDepartment"] = searchTerm;
            return PartialView("_searchDepartment", resultDepartment);
        }

        // Display Status Grid View to Select the Project Name
        public ActionResult searchStatus(string searchTerm)
        {
            var resultStatus = from p in _ctx.proj_info
                           .Include("proj_status")
                           .Where(p => p.proj_status.proj_status_desc.Contains(searchTerm))
                               select p;

            ViewData ["byStatus"] = searchTerm;
            return PartialView("_searchStatus", resultStatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateManager(int id, proj_mgr projmgr)
        {
            string projDesc = projectInfo.returnProjectDescription(id);

            if (TryUpdateModel(projmgr))
            {
                _ctx.proj_mgr.Add(projmgr);
                _ctx.SaveChanges();
                return RedirectToAction("Index", new { searchTerm = projDesc });
            }
            return View(projmgr);
        }

        // Add Full Manager Name
        public ActionResult CreateManager(int id)
        {
            proj_mgr model = proj_mgrInfo.GetProj_Mgr();
            return PartialView("_CreateManager", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSponsor(int id, proj_sponsor sponsor)
        {
            string projDesc = projectInfo.returnProjectDescription(id);

            if (TryUpdateModel(sponsor))
            {
                _ctx.proj_sponsor.Add(sponsor);
                _ctx.SaveChanges();
                return RedirectToAction("Index", new { searchTerm = projDesc });
            }
            return View(sponsor);
        }

        //          Add Full Sponsor Name Record                        //
        public ActionResult CreateSponsor(int id)
        {
            proj_sponsor model = proj_sponsorInfo.GetProj_Sponsor();
            return PartialView("_CreateSponsor", model);
        }

        //          Add Departamental Record to PMFocus.                //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(int id, dept dept)
        {
            string projDesc = projectInfo.returnProjectDescription(id);

            if (TryUpdateModel(dept))
            {
                _ctx.depts.Add(dept);
                _ctx.SaveChanges();
                return RedirectToAction("Index", new { searchTerm = projDesc });
            }
            return View(dept);
        }

        // Add Department Record
        public ActionResult CreateDepartment()
        {
            dept model = new dept 
            {
                dept_desc   = string.Empty ,
                createdby   = User.Identity.Name.Replace("GREENSPOONMARDE\\", ""),
                createddate = DateTime.Now
            };
            
            return PartialView("_CreateDepartment", model);
        }

        // Model binding sample code to UPDATE
        public ActionResult editModelBinding(int id, FormCollection collection)
        {
            var model = _ctx.proj_info.Single(p => p.proj_info_id == id);
            // ASP.NET MVC 4 TryUpdateModel will do is go through a process known as model binding
            // model binding happens anytime you have a parameter in an action method, when I say TryUpdateModel on model, the model binder will go out and look at model
            if (TryUpdateModel(model))
            {
                // But if TryUpdateModel works, this is the point where I would save that into the database.
            }
            // else if anything fails, if any validation error occurs, TryUpdateModel will return false, and I don't want to save that model; and it that happens I'll let the user fix whatever problem they have
            return View(model);
        }

//        [HttpPost]
        public ActionResult UpdateProject(proj_infoViewModel info, int id)
        {
            // this is how you access the list of errors that can occur during the model binding.
            if (!ModelState.IsValid)
                return View(info);

            var p = projectInfo.GetProjectInfo(id);
            if (p == null)
                return RedirectToAction("Index");

            string projDesc = info._proj_name;
            var  pi = new proj_info
            {
                proj_info_id        =   id,
                proj_name           =   info._proj_name,
                proj_mgr_id         =   info._proj_mgr_id,
                proj_sponsor_id     =   info._proj_sponsor_id,
                charter             =   info._charter,
                scope_definition    =   info._scope_definition,
                dept_id             =   info._dept_id,
                client              =   info._client,
                proj_start_date     =   info._proj_start_date.Value,
                proj_end_date       =   info._proj_end_date,
                proj_status_id      =   info._proj_status_id,
                project_type_id     =   info.proj_type_id,
                createdby           =   User.Identity.Name.Replace("GREENSPOONMARDE\\", ""),
                createddate         =   DateTime.Now,
                notes               =   info._notes,
                proj_goal           =   info._proj_goal,
                doc_location        =   info._doc_location
            };

            var existingProjInfo = _ctx.proj_info.Find(pi.proj_info_id);
            if (existingProjInfo != null)
            {
                // entity already in the context
                var attachedEntry = _ctx.Entry(existingProjInfo);
                attachedEntry.CurrentValues.SetValues(pi);
            }
            _ctx.SaveChanges();
            TempData["ConfirmationMessage"] = pi.proj_name + " has been updated.";
            // I want to redirect here instead of just letting the users sit on the save values on that posted form fields, it is very common after HTTP POST you redirect them back to a page where they
            // can view the changed results, THAT WAY, they don't hit refresh on the result of this post operation and accidentally submit something twice.
            return RedirectToAction("Index", new { searchTerm = projDesc });
        }

        // Get /proj_
        public ActionResult createStakeHolder(int id)
        {
            //            stakeholder stake = stakeholderInfo.GetStakeholder();
            stakeholderViewModel holder = new stakeholderViewModel
            {
                //_stakeholder_id          =   0,
                _stakeholder_first_name = string.Empty,
                _stakeholder_last_name = string.Empty,
                _stakeholder_phone = string.Empty,
                _stakeholder_gm_ext = null,
                _stakeholder_email = string.Empty,
                _notes = string.Empty,
                _createdby = User.Identity.Name.Replace("GREENSPOONMARDE\\", ""),
                _createddate = DateTime.Now
            };

            return PartialView("_createStakeHolder", holder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createStakeHolder(stakeholderViewModel stakeholderViewModel, int id)
        {
            string projDesc = projectInfo.returnProjectDescription(id);

            if (ModelState.IsValid)
            {
                var s = new proj_stakeholder
                {
                    proj_info_id = id,
                    stakeholder_id = stakeholderViewModel._stakeholder_id,
                    createdby = stakeholderViewModel._createdby,
                    createddate = stakeholderViewModel._createddate.Value
                };
                _ctx.proj_stakeholder.Add(s);
                _ctx.SaveChanges();

                return RedirectToAction("Index", new { searchTerm = projDesc });
            }

            return View(stakeholderViewModel);
        }

        // GET Request
        public ActionResult CreateProject()
        {

            proj_infoViewModel projInfo = new proj_infoViewModel
            {
                _proj_name          =   string.Empty,
                _proj_mgr_id        =   1,
                _proj_sponsor_id    =   1,
                _charter            =   false,
                _scope_definition   =   string.Empty,
                _dept_id            =   1,
                _client             =   string.Empty,
                _proj_start_date    =   DateTime.Now,
                _proj_end_date      =   null,   
                _proj_status_id     =   1,
                proj_type_id        =   1,
                _createdby          =   User.Identity.Name.Replace("GREENSPOONMARDE\\", ""),
                _createddate        =   DateTime.Now,
                _notes              =   string.Empty,
                _proj_goal          =   string.Empty,
                _doc_location       =   string.Empty
            };
            return PartialView("CreateProject", projInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(proj_infoViewModel info)
        {
            string projDesc = info._proj_name;

            if (ModelState.IsValid)
            {
                var p = new proj_info
                {
                    proj_name           = info._proj_name,
                    proj_mgr_id         = info._proj_mgr_id,
                    proj_sponsor_id     = info._proj_sponsor_id,
                    charter             = info._charter,
                    scope_definition    = info._scope_definition,
                    dept_id             = info._dept_id,
                    client              = info._client,
                    proj_start_date     = info._proj_start_date.Value,
                    proj_end_date       = info._proj_end_date,
                    proj_status_id      = info._proj_status_id,
                    project_type_id     = info.proj_type_id,
                    createdby           = info._createdby,
                    createddate         = info._createddate.Value,
                    notes               = info._notes,
                    proj_goal           = info._proj_goal,
                    doc_location        = info._doc_location
                };
                    _ctx.proj_info.Add(p);
                    _ctx.SaveChanges();
                    return RedirectToAction("Index", new { searchTerm = projDesc });
                
            }

            return View(info);
        }

        // GET /proj_log/Create
        public ActionResult createLog(int id)
        {
            proj_log log = new proj_log
            {
                proj_info_id        = id,
                proj_log_code_id    = 0,
                action_from         = string.Empty,
                action_to           = string.Empty,
                comments            = string.Empty,
                createdby           = User.Identity.Name.Replace("GREENSPOONMARDE\\", ""),
                createddate         = DateTime.Now,
                action_date_from    = null,
                action_date_to      = null
            };

            return PartialView(log);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createLog(proj_log proj_log, string command)
        {
            string projDesc = projectInfo.returnProjectDescription(proj_log.proj_info_id);

            if (ModelState.IsValid) // the ModelState class encapsulate the state of the model binding, and contains both value and errors. it determine whether any erros were encountered during the model binding.
            {
                _ctx.proj_log.Add(proj_log);
                _ctx.SaveChanges();

                // Allows you to store data that will survive for a redirect. Internally it uses the Session as baking store, it's just that after the redirect is made the data is automatically evicted
                //TempData["ConfirmationMessage"] = proj_log.proj_info_id + " has been added";
                return RedirectToAction("Index", new { searchTerm = projDesc });
            }

            return View(proj_log);
        }

        public ActionResult gridstakeholder(int id)
        {
            var model = _ctx.proj_stakeholder
                        .Where(s => s.proj_info_id == id)
                        .Include(s => s.stakeholder)
                        .Select(s => new stakeholderViewModel
                        {
                            _proj_info_id = s.proj_info_id,
                            _stakeholder_id = s.proj_stakeholder_id,
                            _stakeholder_first_name = s.stakeholder.stakeholder_first_name,
                            _stakeholder_last_name = s.stakeholder.stakeholder_last_name,
                            _stakeholder_phone = s.stakeholder.stakeholder_phone,
                            _stakeholder_gm_ext = s.stakeholder.stakeholder_gm_ext,
                            _stakeholder_email = s.stakeholder.stakeholder_email,
                            _notes = s.stakeholder.notes,
                            _createdby = s.stakeholder.createdby,
                            _createddate = s.stakeholder.createddate
                        })
                        .ToList();

            ViewData["projectInfoID"] = id;

            return PartialView("_gridstakeholder", model);
        }

        //[ChildActionOnly]
        public ActionResult gridListLog(int id)
        {
            var model =
            from l in _ctx.proj_log
            where l.proj_info_id == id
            orderby l.proj_log_id
            select new proj_logViewModel
            {
                _proj_info_id = l.proj_info_id,
                _proj_log_code_id = l.proj_log_code_id,
                _action_from = l.action_from,
                _action_to = l.action_to,
                _comments = l.comments,
                _createdby = l.createdby,
                _createddate = l.createddate,
                _action_date_from = l.action_date_from,
                _action_date_to = l.action_date_to
            };

            ViewData["projectInfoID"] = id;

            return PartialView("_gridListLog", model);
            //            return View(model);
        }

        // ===========================Stakeholder Search ==============================================
        public ActionResult AutoCompleteStakeholder(string term)
        {
            var model = _ctx.proj_stakeholder
                        .Include("stakeholder")
                        .Where(s => s.stakeholder.stakeholder_first_name.Contains(term))
                        .Take(10)
                        .Select( s => new
                               {
                                   label = s.stakeholder_id,
                                   value = s.stakeholder.stakeholder_first_name
                               });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // ===========================Department Search ==============================================
        public ActionResult AutoCompleteDepartment(string term)
        {
            var model = _ctx.proj_info
                        .Where(p => p.dept.dept_desc.StartsWith(term))
                        .Take(10)
                        .Select(p => new
                        {
                            label = p.dept.dept_desc
                        });
            return Json(model, JsonRequestBehavior.AllowGet); // it'll serialize my model into JSON format.
        }

        // ============================Status Search =============================================
        public ActionResult AutoCompleteStatus(string term)
        {
            var model = _ctx.proj_info
                        .Where(p => p.proj_status.proj_status_desc.StartsWith(term))
                        .Take(10)
                        .Select(p => new
                        {
                            label = p.proj_status.proj_status_desc
                        });
            return Json(model, JsonRequestBehavior.AllowGet); // it'll serialize my model into JSON format
        }

        //autcomplete to make a request to the server and find possible matches, of course we'll be calling a controller action, and the controller action
        // needs to return JSON (i.e., one of the formats that autocomplete can work with.
        public ActionResult projectSearch(string term)
        {
            var model =
                _ctx.proj_info
                .Where(r => r.proj_name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.proj_name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, string dropDownList = null)
        {
            var cDescription = string.Empty;
            var result = new proj_infoViewModel();
            var resultStatus = new proj_info();
            try
            {
                switch (dropDownList)
                {
                    case "1":
                        goto default;
                    case "2":
                        cDescription = "StakeHolder";
                        return RedirectToAction("searchStakeholder", new { searchTerm = searchTerm } );
//                        break;
                    case "3":
                        cDescription = "Status";
                        return RedirectToAction("searchStatus", new { searchTerm = searchTerm });
//                        break;
                    case "4":
                        cDescription = "Department";
                        return RedirectToAction("searchDepartment", new { searchTerm = searchTerm });
                        //break;
                    default:
                        cDescription = "Project Name";
                        result =
                                (from pi in _ctx.proj_info
                                                    .Include("proj_mgr.proj_sponsor.proj_type.proj_status.dept")
                                 select new proj_infoViewModel
                                 {
                                     _proj_info_id      =   pi.proj_info_id,
                                     _proj_name         =   pi.proj_name,
                                     _proj_mgr_id       =   pi.proj_mgr_id,
                                     _proj_sponsor_id   =   pi.proj_sponsor_id,
                                     _proj_goal         =   pi.proj_goal,
                                     _charter           =   pi.charter.Value,
                                     _scope_definition  =   pi.scope_definition,
                                     proj_type_id       =   pi.project_type_id,
                                     _proj_status_id    =   pi.proj_status_id,
                                     _dept_id           =   pi.dept_id.Value,
                                     _client            =   pi.client,
                                     _proj_start_date   =   pi.proj_start_date,
                                     _proj_end_date     =   pi.proj_end_date,
                                     _notes             =   pi.notes,
                                     _doc_location      =   pi.doc_location,
                                     _createdby         =   pi.createdby,
                                     _createddate       =   pi.createddate
                                 }).FirstOrDefault(r => searchTerm == null || r._proj_name.StartsWith(searchTerm));
                        break;
                }
            }
            catch
            {
                DisplayMessage(searchTerm, cDescription);
            }

            return View(result);

        }

        private void DisplayMessage(string searchTerm, string cDescription, bool error = true, int count = 0)
        {
            if (error == true)
            {
                //                lblMessage.Text = string.Format("Your search in \"{0}\" for \"{1}\" did not return any record.", cDescription, key);
            }
            else
            {
                //                lblMessage.Text = string.Format("[ {0} ] Records found for search in \"{1}\" for \"{2}\" ", count, cDescription, key);
                //                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }

    }
}
