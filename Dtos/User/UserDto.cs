using EventManagement.Server.Enums;

namespace EventManagement.Server.Dtos.User;

public record UserDto(
    string Id,
    RolesEnum Role);