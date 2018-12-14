using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolPrj.Models
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext() : base("default") { }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}