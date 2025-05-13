using EventManagement.Server.Dtos.User;

namespace EventManagement.Server.Repositories.Users;

public interface IUsersRepository : IRepository
{
    public Task<UserDto?> GetUserByIdAsync(string id);
    public Task<UserDto> AddUserAsync(UserDto user);
    public Task<bool> DeleteUserById(string id);
}