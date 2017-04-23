using Job_Finder.Data.UnitOfWork;
using Job_Finder.Web.Areas.Company.ViewModels;
using Job_Finder.Web.Controllers;
using Job_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Job_Finder.Data;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    [Authorize]
    public class CreateController : BaseController
    {
        public CreateController(IJobData data)
            : base(data)
        {

        }

        // GET: Company/Create
        public ActionResult Index()
        {
            var user = base.UserProfile;
            var isCompanyCreated = IsUserCreateCompanyProfile(user);
            if (isCompanyCreated)
            {
                return RedirectToProfilePage();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompany(CreateCompanyViewModel data)
        {
            var user = base.UserProfile;
            var isCompanyCreated = IsUserCreateCompanyProfile(user);
            string logoName = null;
            var pathToFolderLogo = "/Content/Logos/Companies/";

            if (!isCompanyCreated)
            {
                if (data.Logo != null)
                {
                    var fileExtension = this.GetFileExtension(data.Logo.FileName);
                    logoName = user.Id + "." + fileExtension;
                    data.Logo.SaveAs(Server.MapPath("~" + pathToFolderLogo) + logoName);
                }
                else 
                {
                    logoName = "no-image.png";
                }

                var newCompanyCreation = new CompanyInfo
                {
                    Name = data.CompanyName,
                    SiteUrl = data.ComapnyUrl,
                    About = data.CompanyAbout,
                    User = user,
                    Contact = data.CompanyContact,
                    LogoUrl = (pathToFolderLogo + logoName)
                };

                var newVotingSystem = new CompanyRating
                {
                    Benefit = 0,
                    Opportunity = 0,
                    Respect = 0,
                    Salary = 0,
                    Stress = 0,
                    CompanyInfo = newCompanyCreation
                };

                this.Data.Company.Add(newCompanyCreation);
                this.Data.CompanyRatings.Add(newVotingSystem);
                this.Data.SaveChanges();

                this.AddUserToRole("Company");

                return RedirectToProfilePage();
            }
            else
            {
                return RedirectToProfilePage();
            }
        }

        private static bool IsUserCreateCompanyProfile(ApplicationUser user)
        {
            var isCompanyCreated = user.Companies.Any();
            return isCompanyCreated;
        }

        private ActionResult RedirectToProfilePage()
        {
            return RedirectToAction("Index", "Profile");
        }
    }
}