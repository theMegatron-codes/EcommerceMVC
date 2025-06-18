using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class DataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedRolesAsync()
        {
            string[] roleNames = { "Admin", "Customer" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async Task SeedAdminUserAsync()
        {
            var adminEmail = "Aalok.bajgain123@gmail.com";
            var adminPassword = "Aalok@123";  // Use a strong password in real apps!

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                // Create your custom ApplicationUser, not IdentityUser
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    // You can log errors here
                    throw new System.Exception("Failed to create admin user");
                }
            }
            else
            {
                if (!await _userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedAdminUserAsync();
        }
    }
}
