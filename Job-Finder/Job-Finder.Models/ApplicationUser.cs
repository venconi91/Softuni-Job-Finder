using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Votes = new HashSet<AnnouncementVote>();
            this.UserAnnouncement = new HashSet<UserAnnouncement>();
            this.Certificates = new HashSet<UserCertificate>();
            this.Projects = new HashSet<UserProject>();
            this.ProgramingSkills = new HashSet<ProgramingSkill>();
            this.Companies = new HashSet<CompanyInfo>();
            this.Educations = new HashSet<Education>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string City { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string About { get; set; }

        public virtual ICollection<UserAnnouncement> UserAnnouncement{ get; set; }

        public virtual ICollection<AnnouncementVote> Votes { get; set; }

        public virtual ICollection<UserCertificate> Certificates { get; set; }

        public virtual ICollection<UserProject> Projects { get; set; }

        public virtual ICollection<ProgramingSkill> ProgramingSkills { get; set; }

        public virtual ICollection<CompanyInfo> Companies { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
