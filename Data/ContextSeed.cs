using BugTracker.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class ContextSeed
    {
        //adds default roles to database
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Roles.Basic.ToString()));
        }

        //creates default superadmin user with all other roles in database
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin@admin.com",
                Email = "superadmin@admin.com",
                FirstName = "Ramazan",
                LastName = "Ozdemir",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "P@ssword1");
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Models.Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
