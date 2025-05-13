namespace EventManagement.Server.Models;

public class EventTags
{
    public int EventId { get; set; }
    public int TagId { get; set; }
    
    public virtual ICollection<Tags>? Tag { get; set; }
    public virtual ICollection<Events>? Event { get; set; }
}