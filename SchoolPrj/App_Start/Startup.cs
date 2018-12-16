using Microsoft.Owin;
using Owin;
using SchoolPrj.Models;

[assembly: OwinStartup(typeof(SchoolPrj.App_Start.Startup))]

namespace SchoolPrj.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(DatabaseContext.Create);
            app.CreatePerOwinContext<DatabaseManager>(DatabaseManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
        }
    }
}
