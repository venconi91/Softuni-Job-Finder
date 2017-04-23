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
using Job_Finder.Data.UnitOfWork;
using Microsoft.AspNet.Identity;

namespace Job_Finder.Web.Controllers
{
    [Authorize]
    public class UserCertificatesController : BaseController
    {
        public UserCertificatesController(IJobData data)
            :base(data)
        {

        }

        // GET: UserCertificates
        public ActionResult Index()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var userSertificates = this.Data.UserCertificates.All().Where(s=> s.ApplicationUser.Id == currentUserId);
            return View(userSertificates);
        }

        // GET: UserCertificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCertificate userCertificate = this.Data.UserCertificates.Find(id);
            if (userCertificate == null)
            {
                return HttpNotFound();
            }
            return View(userCertificate);
        }

        // GET: UserCertificates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DateTime,ConfirmationUrl,UserId")] UserCertificate userCertificate)
        {
            if (ModelState.IsValid)
            {
                this.Data.UserCertificates.Add(userCertificate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userCertificate);
        }

        // GET: UserCertificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCertificate userCertificate = this.Data.UserCertificates.Find(id);
            if (userCertificate == null)
            {
                return HttpNotFound();
            }
            return View(userCertificate);
        }

        //// POST: UserCertificates/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Description,DateTime,ConfirmationUrl,UserId")] UserCertificate userCertificate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userCertificate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userCertificate);
        //}

        // GET: UserCertificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCertificate userCertificate = this.Data.UserCertificates.Find(id);
            if (userCertificate == null)
            {
                return HttpNotFound();
            }
            return View(userCertificate);
        }

        // POST: UserCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCertificate userCertificate = this.Data.UserCertificates.Find(id);
            this.Data.UserCertificates.Delete(userCertificate);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
