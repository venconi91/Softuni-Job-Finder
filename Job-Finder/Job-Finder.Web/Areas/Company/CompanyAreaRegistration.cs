using System.Web.Mvc;

namespace Job_Finder.Web.Areas.Company
{
    public class CompanyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Company";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Company_default",
                "Company/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

          //  context.MapRoute(
          //    "Company_View_default",
          //    "Company/{controller}/{id}",
          //    new { action = "Index", id = UrlParameter.Optional }
          //);
        }
    }
}