using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace SchoolPrj.Models
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<ApplicationRole> roles = new List<ApplicationRole>
            {
                new ApplicationRole {Name = "Admin"},
                new ApplicationRole {Name = "User"}
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var store = new UserStore<ApplicationUser>(context);
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager(store);
            ApplicationUser admin = new ApplicationUser() { Email = "root@root.com", UserName = "root" };
            var result = userDatabaseManager.Create(admin, "147753");
            userDatabaseManager.AddToRole(admin.Id, "Admin");
            context.SaveChanges();
            base.Seed(context);
        }
    }
}