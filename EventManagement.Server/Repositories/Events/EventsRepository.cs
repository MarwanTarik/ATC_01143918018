using EventManagement.Server.Data;
using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Repositories.Events;

public class EventsRepository(ApplicationDbContext context) : Repository(context), IEventsRepository
{
    private readonly DbSet<Models.Events> _dbSet = context.Set<Models.Events>();
    
    public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
    {
        var events = await _dbSet
            .AsNoTracking()
            .ToListAsync();
        return events.Select<Models.Events, EventDto>(e => e.ToDto());
    }

    public Task<EventDto?> GetEventByIdAsync(int eventId)
    {
        var eventModel = _dbSet
            .FirstOrDefault(e => e.Id == eventId);
        return Task.FromResult(eventModel?.ToDto());
    }

    public Task<IEnumerable<EventDto>> GetEventsByUserIdAsync(string userId)
    {
        var events = _dbSet
            .Where(e => e.UserId == userId)
            .AsNoTracking()
            .ToListAsync();

        return Task.FromResult(events.Result.Select<Models.Events, EventDto>(e => e.ToDto()));
    }
    
    public async Task AddEventAsync(AddEventDto eventDto, string userId)
    {
        
       await _dbSet
           .AddAsync(
               eventDto
                   .ToModel(createdAt: DateTime.Now, updatedAt: DateTime.Now, userId: userId));
    }

    public async Task<bool> DeleteEventAsync(int eventId, string userId)
    {
        var rows = await _dbSet
            .Where(e => e.Id == eventId && e.UserId == userId)
            .ExecuteDeleteAsync();
        return rows > 0;
    }
    
    public async Task<bool> UpdateEventAsync(int eventId, string userId, UpdateEventDto eventDto)
    {
        var eventModel = await _dbSet
            .Where(e => e.Id == eventId && e.UserId == userId)
            .ExecuteUpdateAsync(p =>
                p.SetProperty(e => e.Name, eventDto.Name)
                    .SetProperty(e => e.Description, eventDto.Description)
                    .SetProperty(e => e.EventDate, eventDto.EventDate)
                    .SetProperty(e => e.Price, eventDto.Price)
                    .SetProperty(e => e.Venue, eventDto.Venue)
                    .SetProperty(e => e.AvailableTickets, eventDto.AvailableTickets)
                    .SetProperty(e => e.StatusId, eventDto.StatusId)
                    .SetProperty(e => e.UpdatedAt, DateTime.Now));
        
        return eventModel > 0;
    }
}