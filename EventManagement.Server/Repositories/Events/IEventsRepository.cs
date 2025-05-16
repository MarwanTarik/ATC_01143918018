using EventManagement.Server.Dtos.Event;

namespace EventManagement.Server.Repositories.Events;

public interface IEventsRepository : IRepository
{
    Task<IEnumerable<EventDto>> GetAllEventsAsync();
    Task<EventDto?> GetEventByIdAsync(int eventId);
    Task<IEnumerable<EventDto>> GetEventsByUserIdAsync(string userId);
    Task AddEventAsync(AddEventDto eventDto, string userId);
    Task<bool> DeleteEventAsync(int eventId, string userId);
    Task<bool> UpdateEventAsync(int eventId, string userId, UpdateEventDto eventDto);
}