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

namespace Job_Finder.Web.Controllers
{
    public class ProgramingSkillsController : BaseController
    {
        public ProgramingSkillsController(IJobData data)
            : base(data)
        {

        }

        // GET: ProgramingSkills
        public ActionResult Index()
        {
            return View(this.Data.ProgramingSkills.All().ToList());
        }

        // GET: ProgramingSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramingSkill programingSkill = this.Data.ProgramingSkills.Find(id);
            if (programingSkill == null)
            {
                return HttpNotFound();
            }
            return View(programingSkill);
        }

        [HttpPost]
        public ActionResult AddSkill(string newSkill)
        {
            var skill = this.Data.ProgramingSkills.All().Where(x => x.Name == newSkill).FirstOrDefault();
            if (skill == null)
            {
                var newskill = new ProgramingSkill()
                {
                    Name = newSkill
                };

                this.Data.ProgramingSkills.Add(newskill);
                this.UserProfile.ProgramingSkills.Add(newskill);
            }
            else
            {
                this.UserProfile.ProgramingSkills.Add(skill);
            }
            this.Data.SaveChanges();
            var allUserSkills =
                this.Data.ApplicationUsers.All()
                    .Where(u => u.Id == this.UserProfile.Id)
                    .FirstOrDefault()
                    .ProgramingSkills;
            return this.PartialView("_AllUsersSkillsTemplate", allUserSkills);
        }


        // POST: ProgramingSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name")] ProgramingSkill programingSkill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.Data.ProgramingSkills.Add(programingSkill);
        //        this.Data.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(programingSkill);
        //}

        // GET: ProgramingSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramingSkill programingSkill = this.Data.ProgramingSkills.Find(id);
            if (programingSkill == null)
            {
                return HttpNotFound();
            }
            return View(programingSkill);
        }

        // POST: ProgramingSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] ProgramingSkill programingSkill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(programingSkill).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(programingSkill);
        //}

        // GET: ProgramingSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramingSkill programingSkill = this.Data.ProgramingSkills.Find(id);
            if (programingSkill == null)
            {
                return HttpNotFound();
            }
            return View(programingSkill);
        }

        // POST: ProgramingSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramingSkill programingSkill = this.Data.ProgramingSkills.Find(id);
            this.Data.ProgramingSkills.Delete(programingSkill);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
