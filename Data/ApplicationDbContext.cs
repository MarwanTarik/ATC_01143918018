using EventManagement.Server.Models;
using EventManagement.Server.Seeders;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.SeedBookingStatuses();
        modelBuilder.SeedEventStatuses();
        modelBuilder.SeedTags();
        modelBuilder.SeedRoles();
    }
    
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<BookingStatus> BookingStatus { get; set; }
    public DbSet<Tags> Tags { get; set; }
    public DbSet<Events> Events { get; set; }
    public DbSet<EventStatus> EventStatus { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<EventTags> EventTags { get; set; }
}