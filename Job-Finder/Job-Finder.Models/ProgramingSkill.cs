using Job_Finder.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class ProgramingSkill
    {
        private IList<String> skillsLabelCollection = new List<String>() 
        {
            "default",
            "primary",
            "success",
            "info",
            "warning",
            "danger"
        };

        public ProgramingSkill()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string stringLabel { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}
