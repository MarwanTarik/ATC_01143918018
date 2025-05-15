using EventManagement.Server.Dtos.Booking;

namespace EventManagement.Server.Repositories.Booking;

public interface IBookingRepository : IRepository
{
    Task<BookingDto> CreateBookingAsync(CreateBookDto booking, string userId);
    Task<IEnumerable<BookingDto>> GetAllUserBookingsAsync(string userId);
    Task<BookingDto?> GetBookingByIdAsync(int eventId, string userId);
}