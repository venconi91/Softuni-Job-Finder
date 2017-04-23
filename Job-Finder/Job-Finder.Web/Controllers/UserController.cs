using Job_Finder.Data;
using Job_Finder.Data.UnitOfWork;
using Job_Finder.Web.ViewModels.User;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Job_Finder.Models;

namespace Job_Finder.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IJobData data)
            :base(data)
        {

        }

        // GET: User
        [Authorize]
        public ActionResult Index(string username)
        {
            AutoMapper.Mapper.CreateMap<ApplicationUser, UserViewModel>();
            var user = this.Data.ApplicationUsers.All().Where(x => x.UserName == username).FirstOrDefault();
            // todo validate user -> if user != null...

            var model = AutoMapper.Mapper.Map<ApplicationUser, UserViewModel>(user);
            return View(model);
        }
    }
}