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

    public static async Task SeedUsersAsync(
    UserManager<ApplicationUser> userManager)
    {
        await CreateUserAsync(
            userManager,
            "admin@dentalclinic.com",
            "Admin@12345678",
            "Arjun",
            "Sharma",
            "Admin");

        await CreateUserAsync(
            userManager,
            "doctor@dentalclinic.com",
            "Doctor@12345678",
            "Rohan",
            "Mehta",
            "Dentist");

        await CreateUserAsync(
            userManager,
            "reception@dentalclinic.com",
            "Reception@12345678",
            "Priya",
            "Kapoor",
            "Reception");
    }

    private static async Task CreateUserAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string firstName,
        string lastName,
        string role)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                IsActive = true
            };

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                throw new Exception(string.Join(
                    ", ", result.Errors.Select(e => e.Description)));
        }

        if (!await userManager.IsInRoleAsync(user, role))
            await userManager.AddToRoleAsync(user, role);
    }
}