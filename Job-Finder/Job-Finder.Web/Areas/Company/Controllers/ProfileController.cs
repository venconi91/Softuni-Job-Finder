using Job_Finder.Data;
using Job_Finder.Data.UnitOfWork;
using Job_Finder.Models;
using Job_Finder.Web.Areas.Company.ViewModels;
using Job_Finder.Web.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IJobData data)
            : base(data)
        {

        }

        // GET: Company/Company
        public ActionResult Index()
        {
            var currentUserId = this.UserProfile.Id;
            var company = this.Data.Company.All().Where(x => x.User.Id == currentUserId).FirstOrDefault();
            company.Rating = this.Data.CompanyRatings.All().Where(x => x.Id == company.Id).FirstOrDefault();
            AutoMapper.Mapper.CreateMap<CompanyInfo, ProfileCompanyViewModel>();
            var model = AutoMapper.Mapper.Map<CompanyInfo, ProfileCompanyViewModel>(company);
            model.IsUserOwner = (company.User.Id == currentUserId);
            model.Logo = company.LogoUrl;
            model.Positions = this.Data.CompanyPositions.SearchFor(x => x.CompanyId == company.Id).ToList();
            return View(model);
        }
    }
}