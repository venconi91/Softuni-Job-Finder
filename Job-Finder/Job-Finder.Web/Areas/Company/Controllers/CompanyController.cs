using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_Finder.Web.Areas.Company.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company/Company
        public ActionResult Index()
        {
            return View();
        }
    }
}