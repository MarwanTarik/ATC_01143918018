using EventManagement.Server.Dtos.Image;
using EventManagement.Server.Dtos.User;

namespace EventManagement.Server.Dtos.Event;

public record EventDto(
    int Id,
    string Name,
    string Description,
    string EventDate,
    decimal Price,
    string Venue,
    int AvailableTickets,
    StatusDto Status,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string CreatedBy);