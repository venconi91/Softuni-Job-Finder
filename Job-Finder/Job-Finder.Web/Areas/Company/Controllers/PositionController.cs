using Job_Finder.Data.UnitOfWork;
using Job_Finder.Models;
using Job_Finder.Web.Areas.Company.InputModel;
using Job_Finder.Web.Areas.Company.ViewModels;
using Job_Finder.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    public class PositionController : BaseController
    {
        public PositionController(IJobData data)
            : base(data)
        {

        }

        // GET: Company/Position
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCompanyPositionInputModel data)
        {
            if (ModelState.IsValid)
            {
                var currentCompany = this.UserProfile.Companies.FirstOrDefault().Id;

                var position = new CompanyPosition
                {
                    Title = data.Title,
                    Description = data.Description,
                    Salary = data.Salary,
                    CompanyId = currentCompany,
                };

                this.Data.CompanyPositions.Add(position);
                this.Data.SaveChanges();

                string source = data.Tags;
                string[] stringSeparators = new string[] { "," };
                var result = source.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < result.Length; i++)
                {
                    var currentTag = result[i].Trim();
                    var tagInDatabase = this.Data.Tags.All().Where(x => x.Text == currentTag).FirstOrDefault();


                    if (tagInDatabase == null)
                    {
                        var createdTag = new Tag()
                        {
                            Text = currentTag
                        };
                        position.Tags.Add(createdTag);
                    }
                    else
                    {
                        position.Tags.Add(tagInDatabase);
                    }

                    this.Data.SaveChanges();
                }

                //this.Data.CompanyPositions.Add(position);

                this.Data.SaveChanges();
            }

            return RedirectToAction("Index", "Profile", new { area = "Company" });
        }

        [HttpPost]
        public ActionResult View(int id)
        {
            var position = this.Data.CompanyPositions.All().Where(x => x.Id == id).FirstOrDefault();
            var viewModel = new PositionViewModel()
            {
                Title = position.Title,
                Description = position.Description,
                Salary = position.Salary,
                Tags = position.Tags
            };

            return PartialView("_PositionPartial",viewModel);
        }
    }
}