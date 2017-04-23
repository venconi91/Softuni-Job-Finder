using Job_Finder.Web.Areas.Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.ViewModels.CompanyPosition
{
    public class CompanyPositionViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? Salary { get; set; }

        public int CompanyId { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}