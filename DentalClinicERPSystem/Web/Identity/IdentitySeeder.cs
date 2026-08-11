using DentalClinicERPSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Web.Identity;

public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(
        RoleManager<IdentityRole> roleManager)
    {
        string[] roles =
        {
            "Admin",
            "Reception",
            "Dentist"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    public static async Task SeedAdminAsync(
    UserManager<ApplicationUser> userManager)
    {
        const string email = "admin@dentalclinic.com";
        const string password = "Admin@12345678";

        var admin = await userManager.FindByEmailAsync(email);

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator",
                IsActive = true
            };

            var result = await userManager.CreateAsync(admin, password);

            if (!result.Succeeded)
                throw new Exception(string.Join(
                    ", ", result.Errors.Select(e => e.Description)));
        }

        if (!await userManager.IsInRoleAsync(admin, "Admin"))
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}