using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class Images
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string ImageName { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string ImageType { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public int UserId { get; set; }
}