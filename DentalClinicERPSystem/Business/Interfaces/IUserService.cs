using Business.DTO;

namespace Business.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserListDto>> GetAllUsersAsync();

    Task<UserListDto?> GetUserByIdAsync(string id);

    Task<bool> CreateUserAsync(CreateUserDto dto);

    Task<bool> UpdateUserAsync(UpdateUserDto dto);

    Task<bool> DeactivateUserAsync(string id);

    Task<bool> ActivateUserAsync(string id);
}