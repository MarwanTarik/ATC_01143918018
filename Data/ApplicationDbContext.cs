using EventManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<BookingStatus> BookingStatus { get; set; }
    public DbSet<Tags> Categories { get; set; }
    public DbSet<Events> Events { get; set; }
    public DbSet<EventStatus> EventStatus { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Users> Users { get; set; }
}