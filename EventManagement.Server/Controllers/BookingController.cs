using EventManagement.Server.Dtos.Booking;
using EventManagement.Server.Dtos.User;
using EventManagement.Server.Enums;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = nameof(PoliciesEnum.RequireUserRole))]
public class BookingController(BookingService bookingService) : ControllerBase
{
    private new UserDto User => (UserDto)HttpContext.Items["user"]!;
    
    [HttpPost("events/{eventId:int}")]
    public async Task<IActionResult> CreateBooking(int eventId, [FromBody] CreateBookDto booking)
    {
        var createdBooking = await bookingService.CreateBookingAsync(booking, User.Id);
        return CreatedAtAction(nameof(CreateBooking), createdBooking);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserBookings()
    {
        var bookings = await bookingService.GetAllUserBookingsAsync(User.Id);
        return Ok(bookings);
    }

    [HttpGet("events/{eventId:int}")]
    public async Task<IActionResult> GetBookingById(int eventId)
    {
        var booking = await bookingService.GetBookingByIdAsync(eventId, User.Id);
        if (booking == null)
        {
            return NotFound();
        }

        return Ok(booking);
    }
}