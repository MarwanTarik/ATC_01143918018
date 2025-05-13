using System.ComponentModel.DataAnnotations;
using EventManagement.Server.Enums;

namespace EventManagement.Server.Models;

public class Users
{
    [Key]
    [StringLength(64)]
    public required string Auth0UserId { get; set; } = string.Empty;
    public required Role Role { get; set; }
    
    public virtual ICollection<Events>? Events { get; set; }
    public virtual ICollection<Bookings>? Bookings { get; set; }
    public virtual ICollection<Images>? Images { get; set; }
}