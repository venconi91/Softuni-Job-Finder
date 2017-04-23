using Job_Finder.Web.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Job_Finder.Models;
using Job_Finder.Data.UnitOfWork;
using Job_Finder.Web.ViewModels.Announcement;

namespace Job_Finder.Web.Controllers
{
    [Authorize]
    public class AnnouncementController : BaseController
    {
        public AnnouncementController(IJobData data)
            : base(data)
        {

        }

        [HttpPost]
        public ActionResult VoteUp(int Id)
        {
            //return Json(new {voted = "yes"});
            var currentUserId = this.UserProfile.Id;
            var announcement = this.Data.UserAnnouncements.All().FirstOrDefault(a => a.Id == Id);
            var voteUp = new AnnouncementVote()
            {
                RatingValue = 1,
                UserAnnouncementId = announcement.Id,
                UserId = currentUserId
            };

            announcement.Votes.Add(voteUp);
            announcement.VotesValue += 1;
            this.Data.SaveChanges();

            var votesViewModel = new VoteValueViewModel()
            {
                Value = announcement.VotesValue
            };

            return this.PartialView("_VotedAnnouncement", votesViewModel);
        }

        public ActionResult VoteDown(int Id)
        {
            var currentUserId = this.UserProfile.Id;
            var announcement = this.Data.UserAnnouncements.All().FirstOrDefault(a => a.Id == Id);
            var voteDown = new AnnouncementVote()
            {
                RatingValue = -1,
                UserAnnouncementId = announcement.Id,
                UserId = currentUserId
            };

            announcement.Votes.Add(voteDown);
            announcement.VotesValue -= 1;
            this.Data.SaveChanges();

            var votesViewModel = new VoteValueViewModel()
            {
                Value = announcement.VotesValue
            };

            return this.PartialView("_VotedAnnouncement", votesViewModel);
        }

        // GET: Announcement
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var announcementCount = this.Data.UserAnnouncements.All().Count();
            var announcements = this.Data.UserAnnouncements.All()
                .Where(a => a.UserId != currentUserId)
                .Select(a => new AnnouncementViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    AvatarUrl = a.User.AvatarUrl,
                    VotesValue = a.VotesValue,
                    UserId = a.UserId,
                    IsUserVoted = a.Votes.Any(v => v.UserId == currentUserId),
                    Username = a.User.UserName
                });

            // TODO use automapper

            //var announcementCollection = (ICollection<AnnouncementViewModel>)announcements;
            //var announcementsCollection = new AnnouncementCollectionViewModel() { announcementCollection = announcements };
            //AutoMapper.Mapper.CreateMap<UserAnnouncement, AnnouncementViewModel>();
            //var VMstores = AutoMapper.Map<IEnumerable<UserAnnouncement>, IEnumerable<AnnouncementViewModel>>(announcements);
            //var announcementsCollection = AutoMapper.Mapper.Map<IEnumerable<UserAnnouncement>, AnnouncementCollectionViewModel>(announcements);

            return this.View(announcements.ToList());
        }

        // GET: Announcement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Announcement/Create
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Announcement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnouncementInputModel announcementModel)
        {
            var currentUserId = this.User.Identity.GetUserId();
            if (ModelState.IsValid && announcementModel != null)
            {
                var announcement = new UserAnnouncement()
                {
                    Title = announcementModel.Title,
                    Description = announcementModel.Description,
                    Datetime = DateTime.Now,
                    UserId = currentUserId
                };

                this.Data.UserAnnouncements.Add(announcement);
                //this.Data.SaveChanges();
                //
                string tagsString = announcementModel.Tags;
                string[] stringSeparators = new string[] { "," };
                var splitedTags = tagsString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitedTags.Length; i++)
                {
                    var currentTag = splitedTags[i].Trim();
                    var tagInDatabase = this.Data.Tags.All().Where(x => x.Text == currentTag).FirstOrDefault();


                    if (tagInDatabase == null)
                    {
                        var createdTag = new Tag()
                        {
                            Text = currentTag
                        };
                        announcement.Tags.Add(createdTag);
                    }
                    else
                    {
                        announcement.Tags.Add(tagInDatabase);
                    }

                    this.Data.SaveChanges();
                }
                //
                return this.RedirectToAction("Index", "Home");
            }
            //


            
            //
            return View(announcementModel);
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
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

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
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
