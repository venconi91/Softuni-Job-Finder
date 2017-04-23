using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job_Finder.Data;
using Job_Finder.Models;
using Job_Finder.Web.Controllers;
using Job_Finder.Data.UnitOfWork;
using Job_Finder.Web.Areas.Company.InputModel;
using System.Threading;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    public class RatingsController : BaseController
    {
        public RatingsController(IJobData data)
            : base(data)
        {

        }

        [HttpPost]
        public ActionResult Create(RatingInputModel model)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var hadskj = model.columnType;
            var parsedRate = double.Parse(model.RateValue.ToString());
            var currentCompany = this.Data.Company.All().Where(x => x.Name == model.company).FirstOrDefault().Id;
            var rating = this.Data.CompanyRatings.All().Where(cr => cr.Id == currentCompany).FirstOrDefault();
            if(model.columnType == "Salary")
            {
                rating.Salary = ((rating.Salary + parsedRate) / 2);
            }

            if (model.columnType == "Stress")
            {
                rating.Stress = ((rating.Stress + parsedRate) / 2);
            }
            if (model.columnType == "Benefit")
            {
                rating.Benefit = ((rating.Benefit + parsedRate) / 2);
            }
            if (model.columnType == "Opportunity")
            {
                rating.Opportunity = ((rating.Opportunity + parsedRate) / 2);
            }
            if (model.columnType == "Respect")
            {
                rating.Respect = ((rating.Respect + parsedRate) / 2);
            }
            this.Data.SaveChanges();
            return this.Redirect("Profile/Index");
        }
    }
}
