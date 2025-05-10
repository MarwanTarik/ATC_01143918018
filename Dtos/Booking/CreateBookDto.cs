namespace EventManagement.Server.Dtos.Booking;

public record CreateBookDto(
    int EventId,
    int UserId,
    int NumberOfTickets);