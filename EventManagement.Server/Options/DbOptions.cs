namespace EventManagement.Server.Options;

public class DbOptions
{
    public static readonly string Db = "Db";
    public required string ConnectionString { set; get; } = string.Empty;
}