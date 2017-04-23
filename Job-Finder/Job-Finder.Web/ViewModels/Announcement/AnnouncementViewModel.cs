using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.ViewModels.Announcement
{
    public class AnnouncementViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsUserVoted { get; set; }

        public int VotesValue { get; set; }
        // TODO: add votes
    }
}