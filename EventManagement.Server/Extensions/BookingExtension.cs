using EventManagement.Server.Dtos.Booking;
using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Enums;
using EventManagement.Server.Models;

namespace EventManagement.Server.Extensions;

public static class BookingExtension
{
    public static BookingDto ToDto(this Bookings booking)
    {
        return new BookingDto(
            Id: booking.Id,
            EventId: booking.EventId,
            UserId: booking.UserId,
            NumberOfTickets: booking.NumberOfBookedTickets,
            Status: new StatusDto(
                StatusId: booking.BookingStatus!.Id,
                StatusName: booking.BookingStatus.Status),
            CreatedAt: booking.BookingDate,
            UpdatedAt: booking.UpdatedAt);
    }
    
    public static Bookings ToModel(this CreateBookDto bookingDto, string userId, DateTime? updatedAt = null)
    {
        return new Bookings
        {
            EventId = bookingDto.EventId,
            UserId = userId,
            NumberOfBookedTickets = bookingDto.NumberOfTickets,
            BookingDate = DateTime.UtcNow,
            UpdatedAt = updatedAt ?? DateTime.UtcNow,
            BookingStatusId = (int)BookingStatusEnum.Booked
        };
    }
}