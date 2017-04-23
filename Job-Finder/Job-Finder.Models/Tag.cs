using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Announcements = new HashSet<UserAnnouncement>();
            this.CompanyPositions = new HashSet<CompanyPosition>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<UserAnnouncement> Announcements { get; set; }

        public virtual ICollection<CompanyPosition> CompanyPositions { get; set; }
    }
}
