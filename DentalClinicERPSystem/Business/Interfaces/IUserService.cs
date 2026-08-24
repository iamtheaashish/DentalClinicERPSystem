using Business.DTO;
using Microsoft.AspNetCore.Identity;

namespace Business.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserListDto>> GetAllUsersAsync();
    Task<IEnumerable<UserListDto>> GetAllDentistAsync();
    Task<UserListDto?> GetUserByIdAsync(string id);

    Task<IdentityResult> CreateUserAsync(CreateUserDto dto);
    Task<IdentityResult> UpdateUserAsync(UpdateUserDto dto);

    Task<IdentityResult> DeactivateUserAsync(string id);

    Task<IdentityResult> ActivateUserAsync(string id);
}