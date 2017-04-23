namespace Job_Finder.Data.Migrations
{
    using Job_Finder.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "Job_Finder.Data.ApplicationDbContext";
        }

        protected override void Seed(Job_Finder.Data.ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = this.SeedApplicationUsers(context);
            context.SaveChanges();
        }

        private IList<ApplicationUser> SeedApplicationUsers(ApplicationDbContext context)
        {

            var usernames = new string[] { "admin", "kiro", "didi", "company" };

            var users = new List<ApplicationUser>();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            foreach (var username in usernames)
            {
                var name = username[0].ToString().ToUpper() + username.Substring(1);
                var user = new ApplicationUser
                {
                    UserName = username,
                    Email = username + "@gmail.com"
                };

                var password = "123456";
                var userCreateResult = userManager.Create(user, password);
                if (userCreateResult.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }
            }

            // Create "Administrator" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // create "Company" role
            var companyRoleCreateResult = roleManager.Create(new IdentityRole("Company"));
            if (!companyRoleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", companyRoleCreateResult.Errors));
            }

            // Add "admin" user to "Administrator" role
            var adminUser = users.First(user => user.UserName == "admin");
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, "Administrator");
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
            // add company user to "Company" role
            var companyUser = users.First(u => u.UserName == "company");
            var addCompanyRoleResult = userManager.AddToRole(companyUser.Id, "Company");
            if (!addCompanyRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addCompanyRoleResult.Errors));
            }

            context.SaveChanges();

            return users;
        }
    }
}
