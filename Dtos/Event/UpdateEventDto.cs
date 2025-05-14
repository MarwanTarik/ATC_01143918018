namespace EventManagement.Server.Dtos.Event;

public class UpdateEventDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public decimal Price { get; set; }
    public string Venue { get; set; } = string.Empty;
    public int AvailableTickets { get; set; }
    public int StatusId { get; set; }
}