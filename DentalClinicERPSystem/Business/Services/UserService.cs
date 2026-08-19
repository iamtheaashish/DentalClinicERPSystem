using Business.DTO;
using Business.Interfaces;
using DentalClinicERPSystem.DataAccess.Data;
using DentalClinicERPSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ActivateUserAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateUserAsync(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeactivateUserAsync(string id)
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

    public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
    {
        throw new NotImplementedException();
    }
}