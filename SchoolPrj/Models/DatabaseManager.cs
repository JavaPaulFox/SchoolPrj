using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SchoolPrj.Models
{
    public class DatabaseManager : UserManager<ApplicationUser>
    {
        public DatabaseManager(IUserStore<ApplicationUser> store) : base(store) { }

        public static DatabaseManager Create (IdentityFactoryOptions<DatabaseManager> options, IOwinContext context)
        {
            DatabaseContext db = context.Get<DatabaseContext>();
            DatabaseManager manager = new DatabaseManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}