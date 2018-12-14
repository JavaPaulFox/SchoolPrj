using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SchoolPrj.App_Start.Startup))]

namespace SchoolPrj.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
