namespace EventManagement.Server.Dtos.Event;

public record AddEventDto(
    string Name,
    string Description, 
    DateTime EventDate,
    decimal Price,
    string Venue,
    int AvailableTickets,
    int ImageId, 
    IEnumerable<int> Tags);