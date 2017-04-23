﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Job_Finder.Web.Areas.Company.InputModel
{
    public class CreateCompanyPositionInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Salary { get; set; }

        public string Tags { get; set; }
    }
}