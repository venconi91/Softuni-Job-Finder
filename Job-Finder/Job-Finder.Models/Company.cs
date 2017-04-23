using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class Company
    {
        public Company()
        {
            this.Projects = new HashSet<CompanyProject>();
            this.Posts = new HashSet<CompanyPost>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string SiteUrl { get; set; }

        public string About { get; set; }

        public int RatingId { get; set; }

        public virtual CompanyRating Rating { get; set; }

        public virtual ICollection<CompanyProject> Projects { get; set; }

        public virtual ICollection<CompanyPost> Posts { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User{ get; set; }    //todo check if has double navigations in database to user
    }
}
