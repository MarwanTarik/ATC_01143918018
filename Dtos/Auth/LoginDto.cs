namespace EventManagement.Server.Dtos.Auth;

public record LoginDto (
    string Email, 
    string Password);