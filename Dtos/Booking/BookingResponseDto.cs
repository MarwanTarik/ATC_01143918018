using EventManagement.Server.Dtos.Event;

namespace EventManagement.Server.Dtos.Booking;

public record BookingResponseDto(
    int Id,
    int EventId,
    int UserId,
    int NumberOfTickets, 
    StatusDto Status, 
    DateTime CreatedAt,
    DateTime UpdatedAt);