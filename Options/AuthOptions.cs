namespace EventManagement.Server.Options;

public class AuthOptions
{
    public static readonly string Auth = "Auth";
    
    public string Domain { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}