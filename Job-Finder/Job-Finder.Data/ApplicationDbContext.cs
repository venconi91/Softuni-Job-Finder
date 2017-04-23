using Job_Finder.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Job_Finder.Data.Migrations;

namespace Job_Finder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<UserProject> UserProjects { get; set;}

        public IDbSet<UserCertificate> UserCertificates { get; set; }

        public IDbSet<UserAnnouncement> UserAnnouncements { get; set; }

        public IDbSet<AnnouncementVote> AnnouncementVotes { get; set; }
        
        public IDbSet<CompanyInfo> Companies { get; set; }

        public IDbSet<CompanyProject> CompanyProjects { get; set; }

        public IDbSet<CompanyPost> CompanyPosts { get; set; }

        public IDbSet<CompanyPosition> CompanyPositions { get; set; }

        public IDbSet<CompanyRating> CompanyRatings { get; set; }

        public IDbSet<Tag> Tags { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public System.Data.Entity.DbSet<Job_Finder.Models.ProgramingSkill> ProgramingSkills { get; set; }

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
