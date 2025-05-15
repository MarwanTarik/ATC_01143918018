using EventManagement.Server.Data;
using EventManagement.Server.Dtos.EventTags;
using EventManagement.Server.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Repositories.EventTags;

public class EventTagsRepository(ApplicationDbContext context): Repository(context), IEventTagsRepository
{
    private readonly DbSet<Models.EventTags> _dbSet = context.Set<Models.EventTags>();
    
    public async Task<IEnumerable<EventTagDto>> GetAllEventTagsAsync(int eventId)
    {
        var eventTagsModel =  await _dbSet
            .Where(e => e.EventId == eventId)
            .ToListAsync();
        
        var eventTags = eventTagsModel.Select(e => e.ToDto());

        return eventTags;
    }

    public async Task AddEventTagsAsync(int eventId, IEnumerable<AddEventTagDto> eventTags)
    {
        var eventTagsModel = eventTags.Select(e => e.ToModel(eventId));
        await _dbSet.AddRangeAsync(eventTagsModel);
    }

    public async Task<bool> DeleteEventTagAsync(int eventId, IEnumerable<int> tagsIds)
    {
        var eventTags = await _dbSet
            .Where(e => e.EventId == eventId && tagsIds.Contains(e.TagId))
            .ToListAsync();

        if (eventTags.Count == 0)
        {
            return false;
        }

        _dbSet.RemoveRange(eventTags);
        return true;
    }
}