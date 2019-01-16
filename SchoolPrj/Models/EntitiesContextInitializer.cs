using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SchoolPrj.Models
{
    public class EntitiesContextInitializer : CreateDatabaseIfNotExists<DatabaseContext>
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
            List<GoodsTypes> goodsTypes = new List<GoodsTypes>()
            {
                new GoodsTypes { Id = Guid.NewGuid(), Name = "Sport"},
                new GoodsTypes { Id = Guid.NewGuid(), Name = "Auto"},
                new GoodsTypes { Id = Guid.NewGuid(), Name = "Сlothes"},
                new GoodsTypes { Id = Guid.NewGuid(), Name = "Home Chemistry"}
            };
            context.GoodsTypes.AddRange(goodsTypes);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}