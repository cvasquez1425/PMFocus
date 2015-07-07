using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ProjectModel.DomainClasses;
using PMFocus.Models.DataLayer;
using System.Data;
using System.Diagnostics;
using System.Data.Entity;

namespace PMFocus.Models.Linq
{
    public class projectInfo
    {
        internal static Expression<Func<proj_info, bool>> EqualsToProjectInfoId(int Id)
        {
            return p => p.proj_info_id == Id;
        }

        private static PMEntities _ctx = new PMEntities();

        // To return the name of the Project 
        internal static string returnProjectDescription(int id)
        {
            var query = _ctx.proj_info.Where(p => p.proj_info_id == id).Select(s => new { proj_desc = s.proj_name }).ToList();
            return query.Select(s => s.proj_desc).Single(); 
        }

        // To return the name of the Project
        public static string GetProjectName(int id)
        {
            var projectName = (from proj in _ctx.proj_info
                               where proj.proj_info_id == id
                               select proj.proj_name).FirstOrDefault();
            return projectName;
        }

        // Add the following method to return a specific Project
        public static proj_info GetProjectInfo(int id)
        {
            using (var ctx = ProjectRepository.CreateContext())
            {
                return ctx.proj_info
                    .SingleOrDefault(EqualsToProjectInfoId(id));
            }
        }

        // Add the following method to return a specific Project
        public static proj_info GetProject(int id)
        {
            return (from proj in _ctx.proj_info
                    where proj.proj_info_id == id
                    select proj).SingleOrDefault();
        }

        // To return a list of all the Projects
        public static IQueryable<proj_info> GetAllProjects()
        {
            return _ctx.proj_info;
        }

        // To return a list of all of the Projects for a specific Proj_Info_id
        public static IQueryable<proj_info> GetAllProjects(int id)
        {
            return from proj in _ctx.proj_info
                   where proj.proj_info_id == id
                   select proj;
        }

        // Methods to add, update, delete, and save individual Project
        public static void AddProject(proj_info proj_info)
        {
            _ctx.proj_info.Add(proj_info);
        }

        // Update 
        //originalEntity represents the object before the change (usually fetched from database before you update). 
        //It must be attached to the context. changedEntity represents the entity with the same key which has been changed.
        public static void UpdateProject(proj_info proj_info, Func<proj_info, int> getKey)
        {
//            _ctx.Entry(proj_info).CurrentValues.SetValues(proj_info);
            if (proj_info == null)
            {
                throw new ArgumentException("Cannot add a null entry");
            }

            // To get information about an entity in question, and it's relation to the current DbContext, you call a DbContext.Entry method
            var entry = _ctx.Entry(proj_info);

//            Debug.Write(entry.State);  //EntityState.Detached

            if (entry.State == EntityState.Detached)
            {
                var set = _ctx.Set<proj_info>();
                proj_info attachedEntity = set.Find(getKey(proj_info));

                if (attachedEntity != null)
                {
                    var attachedEntry = _ctx.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(proj_info);
                }
                else
                {
                    entry.State = EntityState.Modified; // this should attached the entry
                }
            }
        }

        public static void UpdateProject(proj_info proj_info)
        {
            using (var db = new PMEntities())
            {
                var existingProjInfo = db.proj_info.Find(proj_info.proj_info_id);
                if (existingProjInfo != null)
                {
                    // entity already in the context
                    var attachedEntry = db.Entry(existingProjInfo);
                    attachedEntry.CurrentValues.SetValues(proj_info);
                }
                else
                {
                    // Since we don't have it in db, this is a simple add.
                    db.proj_info.Add(proj_info);
                }
            }
        }

        // Delete
        public static void DeleteProject(proj_info proj_info)
        {
            _ctx.proj_info.Remove(proj_info);
        }

        // Save
        public static void Save()
        {
            _ctx.SaveChanges();
        }
    }
}