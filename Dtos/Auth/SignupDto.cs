namespace EventManagement.Server.Dtos.Auth;

public record SignupDto (
    string Name, 
    string Email, 
    string Password, 
    string Role);