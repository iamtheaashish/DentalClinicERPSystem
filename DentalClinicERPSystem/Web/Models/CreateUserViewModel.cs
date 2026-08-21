using Business.DTO;

namespace Web.Models;

public class CreateUserViewModel
{
    public CreateUserDto User { get; set; } = new();
    public List<string> Roles { get; set; } = new();
}
