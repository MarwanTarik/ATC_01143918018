using EventManagement.Server.Dtos.User;

namespace EventManagement.Server.Dtos.Auth;

public record AuthResponse(
    string AccessToken,
    string? RefreshToken,
    UserDto User);
