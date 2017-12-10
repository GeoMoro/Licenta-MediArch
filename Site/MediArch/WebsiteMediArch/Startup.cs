using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteMediArch.Startup))]
namespace WebsiteMediArch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
