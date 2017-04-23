﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class CompanyProject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int  CompanyId { get; set; }
        public virtual CompanyInfo Company { get; set; }
    }
}
