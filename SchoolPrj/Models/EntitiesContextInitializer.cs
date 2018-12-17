using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
        }
    }
}