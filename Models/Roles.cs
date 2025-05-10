using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class Roles
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string RoleName { get; set; } = string.Empty;
}