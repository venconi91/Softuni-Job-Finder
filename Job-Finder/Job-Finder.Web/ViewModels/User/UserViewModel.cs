namespace Job_Finder.Web.ViewModels.User
{
    using Job_Finder.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class UserViewModel
    {
        public string Username { get; set; }

        public string AvatarUrl { get; set; }

        public string About { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<UserAnnouncement> UserAnnouncement { get; set; }

       // public virtual ICollection<AnnouncementVote> Votes { get; set; }

        public virtual ICollection<UserCertificate> Certificates { get; set; }

        public virtual ICollection<UserProject> Projects { get; set; }

        public virtual ICollection<ProgramingSkill> ProgramingSkills { get; set; }
    }
}