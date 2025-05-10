using EventManagement.Server.Dtos.Image;
using EventManagement.Server.Dtos.User;

namespace EventManagement.Server.Dtos.Event;

public record EventResponseDto(
    int Id,
    string Name,
    string Description,
    string EventDate,
    decimal Price,
    string Venue,
    int AvailableTickets,
    StatusDto Status,
    IEnumerable<ImageDto> Images,
    IEnumerable<TagDto> Tags,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    int CreatedBy);