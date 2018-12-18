using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SchoolPrj.Models
{
    public class UserDatabaseManager : UserManager<ApplicationUser>
    {
        public UserDatabaseManager(IUserStore<ApplicationUser> store) : base(store) { }

        public static UserDatabaseManager Create (IdentityFactoryOptions<UserDatabaseManager> options, IOwinContext context)
        {
            DatabaseContext db = context.Get<DatabaseContext>();
            UserDatabaseManager manager = new UserDatabaseManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}