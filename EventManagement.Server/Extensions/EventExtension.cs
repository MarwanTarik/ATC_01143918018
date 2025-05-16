using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Models;

namespace EventManagement.Server.Extentions;

public static class EventExtension
{
    public static EventDto ToDto(this Events eventModel)
    {
        return new EventDto(
            Id: eventModel.Id,
            Name: eventModel.Name,
            Description: eventModel.Description,
            EventDate: eventModel.EventDate.ToString("yyyy-MM-dd"),
            Price: eventModel.Price,
            Venue: eventModel.Venue,
            AvailableTickets: eventModel.AvailableTickets,
            Status: new StatusDto(
                StatusId: eventModel.Status!.Id,
                StatusName: eventModel.Status.Status),
            CreatedAt: eventModel.CreatedAt,
            UpdatedAt: eventModel.UpdatedAt,
            CreatedBy: eventModel.UserId);
    }
    
    public static Events ToModel(this AddEventDto eventDto, DateTime createdAt, DateTime updatedAt, string userId)
    {
        return new Events
        {
            Name = eventDto.Name,
            Description = eventDto.Description,
            EventDate = eventDto.EventDate,
            Price = eventDto.Price,
            Venue = eventDto.Venue,
            AvailableTickets = eventDto.AvailableTickets,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            StatusId = eventDto.StatusId,
            UserId = userId,
        };
    }
    
    public static Events ToModel(this UpdateEventDto eventDto, DateTime updatedAt, string userId)
    {
        return new Events
        {
            Name = eventDto.Name,
            Description = eventDto.Description,
            EventDate = eventDto.EventDate,
            Price = eventDto.Price,
            Venue = eventDto.Venue,
            AvailableTickets = eventDto.AvailableTickets,
            UpdatedAt = updatedAt,
            StatusId = eventDto.StatusId,
            UserId = userId
        };
    }
}