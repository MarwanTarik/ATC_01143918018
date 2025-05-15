using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class EventStatus
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Status { get; set; } = string.Empty;
}