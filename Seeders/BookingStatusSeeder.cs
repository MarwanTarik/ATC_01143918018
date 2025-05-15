using EventManagement.Server.Enums;
using EventManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Seeders;

public static class BookingStatusSeeder
{
    public static void SeedBookingStatuses(this ModelBuilder modelBuilder)
    {
        foreach (var status in Enum.GetValues<BookingStatusEnum>())
        {
            modelBuilder.Entity<Models.BookingStatus>().HasData(
                new Models.BookingStatus { Id = (int)status, Status = status.ToString()}
            );
        }
    }
}