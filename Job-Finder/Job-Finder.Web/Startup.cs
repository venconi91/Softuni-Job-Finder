using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job_Finder.Web.Startup))]
namespace Job_Finder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
