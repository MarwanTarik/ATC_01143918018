using System.ComponentModel.DataAnnotations;

namespace EventManagement.Server.Models;

public class Tags
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public string Tag { get; set; } = string.Empty;
}