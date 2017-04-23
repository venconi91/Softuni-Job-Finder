using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.ViewModels.Announcement
{
    public class AnnouncementCollectionViewModel
    {
        public IEnumerable<AnnouncementViewModel> announcementCollection { get; set; }
    }
}