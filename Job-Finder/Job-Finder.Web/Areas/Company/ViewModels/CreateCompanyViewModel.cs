namespace Job_Finder.Web.Areas.Company.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class CreateCompanyViewModel
    {
        public HttpPostedFileBase Logo { get; set; }

        [Required]
        [Display(Name = "Comany name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company about")]
        public string CompanyAbout { get; set; }

        [Required]
        [Display(Name = "Company contact")]
        public string CompanyContact { get; set; }

        [Required]
        [Display(Name = "Company url")]
        public string ComapnyUrl { get; set; }
    }
}