using Microsoft.AspNetCore.Identity;
using TimeTracker.Server.Models;

namespace MAPS_Blazor_Template.Server.Data
{
    public static class ApplicationDbInitializer
    {

        public static void SeedUsers(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if(roleManager.FindByNameAsync("Setup").Result == null)
            {
                var role = new IdentityRole
                {
                    Name = "Setup"
                };
                roleManager.CreateAsync(role);
            }

            if (roleManager.FindByNameAsync("Reporting").Result == null)
            {
                var role = new IdentityRole
                {
                    Name = "Reporting"
                };
                roleManager.CreateAsync(role);
            }

            if (userManager.FindByEmailAsync("Admin@email").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "Admin@email",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Pasword_123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Setup").Wait();
                    userManager.AddToRoleAsync(user, "Reporting").Wait();
                }
            }
        }
    }
}
