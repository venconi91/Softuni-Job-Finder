using Job_Finder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.Areas.Company.ViewModels
{
    public class ProfileCompanyViewModel
    {
        public string Name { get; set; }

        public string Logo { get; set; }

        public string SiteUrl { get; set; }

        public string About { get; set; }

        public IEnumerable<CompanyPosition> Positions { get; set; }

        public string Contact { get; set; }

        public bool IsUserOwner { get; set; }

        [Required]
        public CompanyRating Rating { get; set; }

        public virtual ICollection<CompanyProject> Projects { get; set; }

        public virtual ICollection<CompanyPost> Posts { get; set; }
    }
}