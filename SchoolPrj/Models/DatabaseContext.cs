using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SchoolPrj.Models
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext() : base("default") { }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public DbSet<GoodsTypes> GoodsTypes { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }
}