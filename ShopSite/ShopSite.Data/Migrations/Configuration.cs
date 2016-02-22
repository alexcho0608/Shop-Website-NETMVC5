namespace ShopSite.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    public class Configuration : DbMigrationsConfiguration<ShopSite.Data.Data.ShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override async void Seed(ShopSite.Data.Data.ShopDbContext context)
        {
            if (context.Items.Any())
            {
                return;
            }

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roles = { "admin", "user" };
            foreach(var role in roles)
            {
                if (!RoleManager.RoleExists(role))
                {
                    RoleManager.Create(new IdentityRole(role));
                }
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@admin.bg"
            };

            var result = userManager.Create(user,"admina");
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, "admin");
                var seed = new SeedData(user);

                seed.Categories.ForEach(x => context.Categories.Add(x));

                seed.Items.ForEach(x => context.Items.Add(x));

                context.SaveChanges();
            }
    //  This method will be called after migrating to the latest version.

    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
    //  to avoid creating duplicate seed data. E.g.
    //
    //    context.People.AddOrUpdate(
    //      p => p.FullName,
    //      new Person { FullName = "Andrew Peters" },
    //      new Person { FullName = "Brice Lambson" },
    //      new Person { FullName = "Rowan Miller" }
    //    );
    //
    }
  }
}
