using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.InputModels
{
    public class AnnouncementInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Tags { get; set; }
    }
}