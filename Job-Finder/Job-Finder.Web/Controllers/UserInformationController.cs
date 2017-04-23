using Job_Finder.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Finder.Web.Controllers
{
    public class UserInformationController : BaseController
    {
        public UserInformationController(IJobData data)
            :base(data)
        {

        }

        public ActionResult ChangeUserAboutInformation(string about)
        {
            this.UserProfile.About = about;
            this.Data.SaveChanges();
            return this.Content(about);
        }
    }
}