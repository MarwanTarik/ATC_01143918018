using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Dtos.EventTags;
using EventManagement.Server.Repositories.Events;

namespace EventManagement.Server.Services;

public class EventsService(IEventsRepository eventsRepository)
{
    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        return await eventsRepository.GetAllEventsAsync();
    }

    public async Task<EventDto?> GetEventByIdAsync(int eventId)
    {
        return await eventsRepository.GetEventByIdAsync(eventId);
    }

    public async Task<IEnumerable<EventDto>> GetEventsByUserIdAsync(string userId)
    {
        return await eventsRepository.GetEventsByUserIdAsync(userId);
    }

    public async Task AddEventAsync(AddEventDto eventDto, string userId)
    {
        await eventsRepository.AddEventAsync(eventDto, userId);
        await eventsRepository.SaveAsync();
    }

    public async Task DeleteEventAsync(int eventId, string userId)
    {
        var result = await eventsRepository.DeleteEventAsync(eventId, userId);
        if (!result)
        {
            throw new KeyNotFoundException($"Event with ID {eventId} not found");
        }
    }
    
    public async Task UpdateEventAsync(int eventId, UpdateEventDto eventDto, string userId)
    {
        var result = await eventsRepository.UpdateEventAsync(eventId, userId, eventDto);
        
        if (!result)
        {
            throw new KeyNotFoundException($"Event with ID {eventId} not found");
        }
    }
}