namespace EventManagement.Server.Options;

public class ApplicationOptions
{
    public const string Application = "Application";

    public required string Auth0RoleClaim { get; set; } = string.Empty;
}