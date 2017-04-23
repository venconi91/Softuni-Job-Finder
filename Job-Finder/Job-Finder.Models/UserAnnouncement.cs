using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class UserAnnouncement
    {
        public UserAnnouncement()
        {
            this.Votes = new HashSet<AnnouncementVote>();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? Salary { get; set; }

        public DateTime Datetime { get; set; }

        [DefaultValue(0)]
        public int VotesValue { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<AnnouncementVote> Votes { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
