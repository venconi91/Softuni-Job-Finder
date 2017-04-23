using Job_Finder.Data.UnitOfWork;
using Job_Finder.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Job_Finder.Web.Areas.Company.ViewModels;
using Job_Finder.Models;
using Job_Finder.Data;
using Job_Finder.Web.ViewModels.CompanyPosition;
using Job_Finder.Web.ViewModels.Announcement;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    [Authorize]
    //[Authorize(Roles="Company")]
    public class RecommendationController : BaseController
    {
        public RecommendationController(IJobData data)
            : base(data)
        {

        }

        // GET: Company/Recommended
        [HttpGet]
        public ActionResult All()
        {

            var currentUserId = this.User.Identity.GetUserId();
            var companyPositions = this.UserProfile.Companies.FirstOrDefault(c => c.User.Id == currentUserId)
                .Positions.Select(p => new CompanyPositionViewModel()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        Salary = p.Salary,
                        CompanyId = p.CompanyId,
                        Tags = p.Tags.Select(t => new TagViewModel() { Id = t.Id, name = t.Text })
                    }
                );

            return this.View(companyPositions);

            //-----------------
            //var currentUserId = this.User.Identity.GetUserId();
            //var companyId = this.UserProfile.Companies.FirstOrDefault(c=>c.User.Id == currentUserId).Id;
            //bool isInRole = this.User.IsInRole("Company");

            //var uniqueCompanyTags = new HashSet<Tag>();

            //var companyPositions = this.Data.CompanyPositions.All().Where(cp => cp.CompanyId == companyId).Select(cp => new { tags = cp.Tags }).ToList();

            //foreach (var cp in companyPositions)
            //{
            //    //cp.tags.ToList().ForEach(t => uniqueCompanyTags.Add(t));  // todo check this
            //    foreach (var tag in cp.tags)
            //    {
            //        uniqueCompanyTags.Add(tag);
            //    }
            //}

            //var uniqueList = uniqueCompanyTags.Select(ut=>ut.Text).ToList();

            ////var matchedAnnouncements0 = this.Data.UserAnnouncements.All()
            ////   .Where(a => a.UserId != currentUserId)
            ////   .Where(a => a.Tags.Select(t=>t.Text).Intersect(uniqueList).Any())
            ////   .Count();

            //var matchedAnnouncements = this.Data.UserAnnouncements.All()
            //   .Where(a => a.UserId != currentUserId)
            //   .Where(a=>a.Tags.Select(t=>t.Text).Intersect(uniqueList).Any())
            //   .Select(a => new RecommendationsViewModel
            //   {
            //       Id = a.Id,
            //       Description = a.Description,
            //       userAvatarUrl = a.User.AvatarUrl,
            //       username = a.User.UserName,
            //       Votes = a.VotesValue,
            //       Title = a.Title,
            //       Tags = a.Tags.Select(t=>new TagViewModel(){Id=t.Id,name = t.Text}),
            //       MatchedCount = a.Tags.Select(t=>t.Text).Intersect(uniqueList).Count(),  // todo check if works
            //   });

            ////foreach (var item in matchedAnnouncements1)
            ////{
            ////    var name = item.Title;
            ////    var matches = string.Join(";", item.Tags);
            ////}

            ////var matchedAnnouncements = this.Data.UserAnnouncements.All()
            ////    .Where(a => a.UserId != currentUserId)
            ////    .Select(a => new RecommendationsViewModel()
            ////    {
            ////        Id = a.Id,
            ////        Title = a.Title,
            ////        Description = a.Description,
            ////        MatchedCount = a.Tags.Intersect(uniqueCompanyTags).Count(),  // todo check if works
            ////        username = a.User.UserName,
            ////        userAvatarUrl = a.User.AvatarUrl,
            ////        Tags = a.Tags.Select(t => new TagViewModel() 
            ////            {
            ////                Id = t.Id,
            ////                name = t.Text
            ////            })
            ////    });


            // todo check this after created company positions
            //return View(matchedAnnouncements.ToList());
        }

        // GET: Company/Recommended/Details/5
        public ActionResult Recommended(int id)
        {
            var positionTags = this.Data.CompanyPositions.All().Where(cp => cp.Id == id).FirstOrDefault().Tags.Select(t => t.Text);

            var matchedAnnouncements = this.Data.UserAnnouncements.All()
                .Where(a => a.Tags.Select(t => t.Text).Intersect(positionTags).Any())
                .Select(au => new RecommendationsViewModel()
                {
                    Id = au.Id,
                    Title = au.Title,
                    Description = au.Description,
                    userAvatarUrl = au.User.AvatarUrl,
                    username = au.User.UserName,
                    Votes = au.VotesValue,
                    MatchedCount = au.Tags.Select(t => t.Text).Intersect(positionTags).Count(),
                    Tags = au.Tags.Select(t => new TagViewModel() { Id = t.Id, name = t.Text })
                });

            return this.PartialView("_Recommended", matchedAnnouncements);
        }

        // GET: Company/Recommended/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Recommended/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Recommended/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Recommended/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Recommended/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Recommended/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
