using EventManagement.Server.Dtos.EventTags;
using EventManagement.Server.Repositories.Events;
using EventManagement.Server.Repositories.EventTags;

namespace EventManagement.Server.Services;

public class EventTagsService(IEventTagsRepository eventTagsRepository)
{
    public async Task DeleteEventTagsAsync(int eventId, IEnumerable<int> tagsIds)
    {
        var result = await eventTagsRepository.DeleteEventTagAsync(eventId, tagsIds);
        if (!result)
        {
            throw new Exception("Failed to delete event tags");
        }
        
        var affected = await eventTagsRepository.SaveAsync();
        if (affected == 0)
        {
            throw new Exception("Failed to delete event tags");
        }
    }

    public async Task AddEventTagsAsync(int eventId, IEnumerable<AddEventTagDto> eventTags)
    {
        await eventTagsRepository.AddEventTagsAsync(eventId, eventTags);
        var affected = await eventTagsRepository.SaveAsync();
        if (affected == 0)
        {
            throw new Exception("Failed to add event tags");
        }
    }
    
    public async Task<IEnumerable<EventTagDto>> GetAllEventTagsAsync(int eventId)
    {
        return await eventTagsRepository.GetAllEventTagsAsync(eventId);
    }
}