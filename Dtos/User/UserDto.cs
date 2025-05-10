namespace EventManagement.Server.Dtos.User;

public record UserDto(
    int Id,
    string Name,
    string Email,
    RoleDto Role);