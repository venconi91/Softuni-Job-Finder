using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class UserProject
    {
        public UserProject()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string GithubRepository { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
