using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.Areas.Company.ViewModels
{
    public class RecommendationsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string userAvatarUrl { get; set; }

        public int Votes { get; set; }

        public string username { get; set; }

        public int MatchedCount { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}