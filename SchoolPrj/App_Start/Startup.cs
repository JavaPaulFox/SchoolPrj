using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
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
            app.CreatePerOwinContext<UserDatabaseManager>(UserDatabaseManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}
