using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class AnnouncementVote
    {
        public int Id { get; set; }

        public double RatingValue { get; set; }

        public int UserAnnouncementId { get; set; }

        public virtual UserAnnouncement UserAnnouncement{ get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
