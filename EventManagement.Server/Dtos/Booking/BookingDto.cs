using EventManagement.Server.Dtos.Event;

namespace EventManagement.Server.Dtos.Booking;

public record BookingDto(
    int Id,
    int EventId,
    string UserId,
    int NumberOfTickets, 
    StatusDto Status, 
    DateTime CreatedAt,
    DateTime UpdatedAt);