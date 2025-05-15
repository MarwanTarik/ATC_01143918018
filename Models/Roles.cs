using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class Roles
{
    public int Id { get; set; }
    
    [MaxLength(64)]
    public string Role { get; set; } = string.Empty;
}