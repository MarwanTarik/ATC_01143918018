using EventManagement.Server.Data;
using EventManagement.Server.Dtos.User;
using EventManagement.Server.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Repositories.Users;

public class UsersRepository(ApplicationDbContext context) : Repository(context), IUsersRepository
{
    private readonly DbSet<Models.Users> _dbSet = context.Set<Models.Users>();
    
    public async Task<UserDto?> GetUserByIdAsync(string id)
    {
        var user = await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Auth0UserId == id);
        return user?.ToUserDto();
    }

    public async Task<UserDto> AddUserAsync(UserDto user)
    {
        var userModel = user.ToModel();
        var result = await _dbSet.AddAsync(userModel);
        return result.Entity.ToUserDto();
    }

    public async Task<bool> DeleteUserById(string id)
    {
        var user = await _dbSet
            .FirstOrDefaultAsync(u => u.Auth0UserId == id);
    
        if (user == null)
            return false;
    
        _dbSet.Remove(user);
        return true;
    }
}