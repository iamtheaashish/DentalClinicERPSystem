using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    

    public async Task<IdentityResult> CreateUserAsync(CreateUserDto dto)
    {
        var user = new ApplicationUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = dto.Email,
            IsActive = dto.IsActive
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            return result;

        if (!string.IsNullOrEmpty(dto.Role))
        {
            var roleResult = await _userManager.AddToRoleAsync(user, dto.Role);

            if (!roleResult.Succeeded)
                return roleResult;
        }

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeactivateUserAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserListDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Select(p => new UserListDto
            {
                Id = p.Id,
                FullName = p.FirstName + " " + p.LastName,
                Email = p.Email!,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt
            }).ToListAsync();
    }

    public async Task<UserListDto?> GetUserByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> UpdateUserAsync(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<UserListDto>> GetAllDentistAsync()
    {
        var dentistRole = await _userManager.GetUsersInRoleAsync("Dentist");
        return dentistRole
                .Where(u => u.IsActive)
                .Select(u => new UserListDto
        {
            Id = u.Id,
            FullName = u.FirstName + " " + u.LastName,
            Email = u.Email!,
            IsActive = u.IsActive,
            CreatedAt = u.CreatedAt
        });
    }

    Task<IdentityResult> IUserService.ActivateUserAsync(string id)
    {
        throw new NotImplementedException();
    }
}