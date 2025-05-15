using EventManagement.Server.Data;
using EventManagement.Server.Dtos.Booking;
using EventManagement.Server.Extensions;
using EventManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Repositories.Booking;

public class BookingRepository(ApplicationDbContext context) : Repository(context), IBookingRepository
{
    private readonly DbSet<Bookings> _dbSet = context.Set<Bookings>();
    
    public async Task<BookingDto> CreateBookingAsync(CreateBookDto booking, string userId)
    {
        var bookingModel = booking.ToModel(userId);
        var bookingEntity = await _dbSet.AddAsync(bookingModel);
        return bookingEntity.Entity.ToDto();
    }

    public async Task<IEnumerable<BookingDto>> GetAllUserBookingsAsync(string userId)
    {
        var bookings = await _dbSet
            .Include(b => b.BookingStatus)
            .Where(b => b.UserId == userId)
            .ToListAsync();
        return bookings.Select(b => b.ToDto()).ToList();
    }

    public async Task<BookingDto?> GetBookingByIdAsync(int eventId, string userId)
    {
        var booking = await _dbSet
            .Include(b => b.BookingStatus)
            .FirstOrDefaultAsync(b => b.EventId == eventId && b.UserId == userId);
        return booking?.ToDto();
    }
}