using Job_Finder.Data.UnitOfWork;
using Job_Finder.Models;
using Job_Finder.Web.Areas.Company.ViewModels;
using Job_Finder.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    public class ViewController : BaseController
    {

        public ViewController(IJobData data)
            : base(data)
        {

        }

        public ActionResult Index(int? Id)
        {
            var company = this.Data.Company.All().Where(x => x.Id == Id).FirstOrDefault();
            if (company == null) 
            {
                throw new Exception("Cuurent page does not exist !");
            }
            AutoMapper.Mapper.CreateMap<CompanyInfo, ProfileCompanyViewModel>();
            var model = AutoMapper.Mapper.Map<CompanyInfo, ProfileCompanyViewModel>(company);
            // TODO: company.UserId does not work.
            model.IsUserOwner = this.UserProfile.Id == company.User.Id;

            return View("../Profile/Index", model);
        }
    }
}