namespace Job_Finder.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Job_Finder.Models;
    using Job_Finder.Data.Repository;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class JobData : IJobData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public JobData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IJobRepository<AnnouncementVote> AnnouncementVotes
        {
            get
            {
                return this.GetRepository<AnnouncementVote>();
            }
        }

        public IJobRepository<ApplicationUser> ApplicationUsers
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IJobRepository<CompanyInfo> Company
        {
            get
            {
                return this.GetRepository<CompanyInfo>();
            }
        }

        public IJobRepository<CompanyPosition> CompanyPositions
        {
            get
            {
                return this.GetRepository<CompanyPosition>();
            }
        }

        public IJobRepository<CompanyPost> CompanyPosts
        {
            get
            {
                return this.GetRepository<CompanyPost>();
            }
        }

        public IJobRepository<CompanyProject> CompanyProjects
        {
            get
            {
                return this.GetRepository<CompanyProject>();
            }
        }

        public IJobRepository<CompanyRating> CompanyRatings
        {
            get
            {
                return this.GetRepository<CompanyRating>();
            }
        }

        public IJobRepository<ProgramingSkill> ProgramingSkills
        {
            get
            {
                return this.GetRepository<ProgramingSkill>();
            }
        }

        public IJobRepository<UserAnnouncement> UserAnnouncements
        {
            get
            {
                return this.GetRepository<UserAnnouncement>();
            }
        }

        public IJobRepository<UserCertificate> UserCertificates
        {
            get
            {
                return this.GetRepository<UserCertificate>();
            }
        }

        public IJobRepository<UserProject> UserProjects
        {
            get
            {
                return this.GetRepository<UserProject>();
            }
        }

        public IJobRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IJobRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(JobRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IJobRepository<T>)this.repositories[typeOfModel];
        }
    }
}
