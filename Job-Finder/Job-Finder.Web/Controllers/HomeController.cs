using Job_Finder.Data.UnitOfWork;
using Job_Finder.Models;
using Job_Finder.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Job_Finder.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IJobData data)
            :base(data)
        {

        }

        public ActionResult Index()
        {
            //this.AddSuccessNotification("some success test");
            //this.AddErrorNotification("some error test");
            //this.AddInfoNotification("some info test");
            //this.AddWarningNotification("some warning test");

            if (this.User.Identity.IsAuthenticated)
            {
                var currentUserId = this.User.Identity.GetUserId();
                AutoMapper.Mapper.CreateMap<ApplicationUser, UserViewModel>();
                var user = this.Data.ApplicationUsers.All().Where(x => x.Id == currentUserId).FirstOrDefault();

                var model = AutoMapper.Mapper.Map<ApplicationUser, UserViewModel>(user);
                return View(model);
            }        
            return this.RedirectToAction("LogIn", "Account");
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}