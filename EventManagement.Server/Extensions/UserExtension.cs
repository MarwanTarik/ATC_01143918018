using EventManagement.Server.Dtos.User;
using EventManagement.Server.Enums;
using EventManagement.Server.Models;

namespace EventManagement.Server.Extentions;

public static class UserExtension
{
    public static UserDto ToUserDto(this Users user)
    {
        return new UserDto(
            Id: user.Auth0UserId,
            Role: (RolesEnum)user.RoleId);
    }

    public static Users ToModel(this UserDto dto)
    {
        return new Users
        {
            Auth0UserId = dto.Id,
            RoleId = (int)dto.Role
        };
    }
}