namespace Application.Migrations
{
    using DataAccess;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Application.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Application.Models.ApplicationDbContext";
        }

        protected override void Seed(Application.Models.ApplicationDbContext context)
        {
            //This method will be called after migrating to the latest version.
            context.Roles.AddOrUpdate(l => l.Id,
                new IdentityRole() { Id = "mngr_myaccount", Name = "mngr_myaccount" },
                new IdentityRole() { Id = "mngr_users", Name = "mngr_users" },
                new IdentityRole() { Id = "mngr_advertisements", Name = "mngr_advertisements" },
                new IdentityRole() { Id = "mngr_configurations", Name = "mngr_configurations" });

            if (!(context.Users.Any(u => u.UserName == "administrator")))
            {
                var userStore = new UserStore<Models.User>(context);
                var userManager = new UserManager<Models.User>(userStore);

                var administrator = new Models.User
                {
                    UserName = "administrator",
                    FirstName = "Administrator",
                    LastName = "",
                    Sex = "m",
                    Title = "",
                    ImageFile = "noimage.png",
                    Email = "contact@company.com",
                    CreationDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddYears(20),
                    IsApproved = true,
                    ApprovedBy = "InitialSetup"
                };

                IdentityResult identityResult = userManager.Create(administrator, "12345678");
                
                if (identityResult.Succeeded)
                {
                    if (administrator.Id != null)
                    {
                        userManager.AddToRoles(administrator.Id,
                        new string[] { "mngr_myaccount",
                        "mngr_users",
                        "mngr_advertisements",
                        "mngr_configurations"});
                    }
                }
            }
        }
    }
}