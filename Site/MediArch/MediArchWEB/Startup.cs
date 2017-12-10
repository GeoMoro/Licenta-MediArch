using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediArchWEB.Startup))]
namespace MediArchWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
