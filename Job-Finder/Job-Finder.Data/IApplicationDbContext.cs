using Job_Finder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Data
{
    public interface IApplicationDbContext
    {
        IDbSet<UserProject> UserProjects { get; set; }

        IDbSet<UserCertificate> UserCertificates { get; set; }

        IDbSet<UserAnnouncement> UserAnnouncements { get; set; }

        IDbSet<AnnouncementVote> AnnouncementVotes { get; set; }

        IDbSet<CompanyInfo> Companies { get; set; }

        IDbSet<CompanyProject> CompanyProjects { get; set; }

        IDbSet<CompanyPost> CompanyPosts { get; set; }

        IDbSet<CompanyPosition> CompanyPositions { get; set; }

        IDbSet<CompanyRating> CompanyRatings { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
