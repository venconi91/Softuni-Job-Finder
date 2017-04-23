using Job_Finder.Data;
using Job_Finder.Data.Migrations;
using Job_Finder.Data.UnitOfWork;
using Job_Finder.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Job_Finder.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private ApplicationUser userProfile;

        protected BaseController(IJobData data)
        {
            this.Data = data;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        protected BaseController(IJobData data, ApplicationUser user)
            : this(data)
        {
            this.UserProfile = user;
        }

        protected IJobData Data { get; private set; }

        protected ApplicationUser UserProfile
        {
            get { return this.userProfile; }
            private set { this.userProfile = value; }
        }

        protected override IAsyncResult BeginExecute(RequestContext requserContext, AsyncCallback callback, object state)
        {
            if (requserContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requserContext.HttpContext.User.Identity.Name;
                var user = this.Data.ApplicationUsers.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requserContext, callback, state);
        }

        protected string GetFileExtension(string file)
        {
            if (file != null)
            {
                string extension = Path.GetExtension(file).Replace(".", "");
                return extension;
            }
            else
            {
                throw new ArgumentNullException("Upladed file extension cannot be null or empty");
            }
        }

        protected void AddUserToRole(string role)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(role))
            {
                var roleCreateResult = roleManager.Create(new IdentityRole(role));
                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(String.Join("; ", roleCreateResult.Errors));
                }
            }

            var userId = this.UserProfile.Id;
            var addRoleResult = userManager.AddToRole(userId, role);
            if (!addRoleResult.Succeeded) 
            {
                throw new Exception(String.Join("; ", addRoleResult.Errors));
            }

            context.SaveChanges();
        }

        protected void AddSuccessNotification(string message)
        {
            this.TempData["SuccessNotification"] += message;
        }

        protected void AddErrorNotification(string message)
        {
            this.TempData["ErrorNotification"] += message;
        }

        protected void AddWarningNotification(string message)
        {
            this.TempData["WarningNotification"] += message;
        }

        protected void AddInfoNotification(string message)
        {
            this.TempData["InfoNotification"] += message;
        }
    }
}
