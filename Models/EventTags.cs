namespace EventManagement.Server.Models;

public class EventTags
{
    public int EventId { get; set; }
    public int TagId { get; set; }
    
    public virtual Events? Event { get; set; }
    public virtual Tags? Tag { get; set; }
}