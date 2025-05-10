using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class Users
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
    
    public int RoleId { get; set; }
    
    [StringLength(500)]
    public string HashedPassword { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string Salt { get; set; } = string.Empty;
    
    public virtual Roles? Role { get; set; }
}