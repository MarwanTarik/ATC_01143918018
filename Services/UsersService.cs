using EventManagement.Server.Dtos.User;
using EventManagement.Server.Repositories.Users;

namespace EventManagement.Server.Services;

public class UsersService(IUsersRepository usersRepository)
{
    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
        return await usersRepository.GetUserByIdAsync(id);
    }

    public async Task<UserDto> AddUserAsync(UserDto user)
    {
        return await usersRepository.AddUserAsync(user);
    }

    public async Task DeleteUserById(string id)
    {
        var result =  await usersRepository.DeleteUserById(id);
        if (!result)
            throw new Exception("User not found");
    }
}