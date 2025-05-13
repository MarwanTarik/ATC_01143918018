namespace EventManagement.Server.Models;

public class Bookings
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int EventId { get; set; }
    
    public int BookingStatusId { get; set; }
    
    public int NumberOfBookedTickets { get; set; }
    
    public DateTime BookingDate { get; set; }
   
    public DateTime UpdatedAt { get; set; }
    
    public virtual Events? Event { get; set; }
    public virtual BookingStatus? BookingStatus { get; set; }
}