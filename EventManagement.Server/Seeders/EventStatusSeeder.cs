using EventManagement.Server.Enums;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Seeders;

public static class EventStatusSeeder
{
    public static void SeedEventStatuses(this ModelBuilder modelBuilder)
    {
        foreach (var status in Enum.GetValues<EventStatusEnum>())
        {
            modelBuilder.Entity<Models.EventStatus>().HasData(
                new Models.EventStatus { Id = (int)status, Status = status.ToString()}
            );
        }
    }
}