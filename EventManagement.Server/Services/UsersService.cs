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
        var userModel = await usersRepository.AddUserAsync(user);
        
        var affected = await usersRepository.SaveAsync();
        if (affected == 0)
            throw new Exception("Failed to add user");

        return userModel;
    }

    public async Task DeleteUserById(string id)
    {
        var result =  await usersRepository.DeleteUserById(id);
        if (!result)
            throw new Exception("Failed to delete user");
        
        var affected = await usersRepository.SaveAsync();
        if (affected == 0)
            throw new Exception("Failed to delete user");
    }
}