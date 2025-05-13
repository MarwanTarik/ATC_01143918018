using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Server.Models;

public class Events
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string Description { get; set; } = string.Empty;
    
    public DateTime EventDate { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [StringLength(255)]
    public string Venue { get; set; } = string.Empty;
    
    public int AvailableTickets { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public int StatusId { get; set; }
    
    public int UserId { get; set; }
    
    public int ImageId { get; set; }
    
    public virtual ICollection<Images>? Image { get; set; }
    public virtual EventStatus? Status { get; set; }
}