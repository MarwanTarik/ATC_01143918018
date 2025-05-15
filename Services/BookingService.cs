using EventManagement.Server.Dtos.Booking;
using EventManagement.Server.Repositories.Booking;

namespace EventManagement.Server.Services;

public class BookingService(IBookingRepository bookingRepository) 
{

    public async Task<BookingDto> CreateBookingAsync(CreateBookDto booking, string userId)
    {
        return await bookingRepository.CreateBookingAsync(booking, userId);
    }

    public async Task<IEnumerable<BookingDto>> GetAllUserBookingsAsync(string userId)
    {
        return await bookingRepository.GetAllUserBookingsAsync(userId);
    }

    public async Task<BookingDto?> GetBookingByIdAsync(int eventId, string userId)
    {
        return await bookingRepository.GetBookingByIdAsync(eventId, userId);
    }
}