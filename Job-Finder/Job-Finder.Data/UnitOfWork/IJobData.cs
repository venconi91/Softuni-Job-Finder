namespace Job_Finder.Data.UnitOfWork
{
    using Job_Finder.Data.Repository;
    using Job_Finder.Models;

    public interface IJobData
    {
        IJobRepository<AnnouncementVote> AnnouncementVotes { get; }
        IJobRepository<ApplicationUser> ApplicationUsers { get; }
        IJobRepository<CompanyInfo> Company { get; }
        IJobRepository<CompanyPosition> CompanyPositions { get; }
        IJobRepository<CompanyPost> CompanyPosts { get; }
        IJobRepository<CompanyProject> CompanyProjects { get; }
        IJobRepository<CompanyRating> CompanyRatings { get; }
        IJobRepository<ProgramingSkill> ProgramingSkills { get; }
        IJobRepository<UserAnnouncement> UserAnnouncements { get; }
        IJobRepository<UserCertificate> UserCertificates { get; }
        IJobRepository<UserProject> UserProjects { get; }
        IJobRepository<Tag> Tags{ get; }
        
        int SaveChanges();
    }
}
