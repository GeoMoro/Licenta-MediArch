using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediArchWebsite.Startup))]
namespace MediArchWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*services.AddTransient<IDataService, DataService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddDbContext<DataService>(opt =>
                opt.UseSqlServer(@"Server = .\SQLEXPRESS; Database = MediArch.Development; Trusted_Connection = true;"));

            services.AddMvc();*/

            ConfigureAuth(app);
        }
    }
}
