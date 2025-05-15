using EventManagement.Server.Dtos.EventTags;

namespace EventManagement.Server.Repositories.EventTags;

public interface IEventTagsRepository : IRepository
{
    Task<IEnumerable<EventTagDto>> GetAllEventTagsAsync(int eventId);
    Task AddEventTagsAsync(int eventId, IEnumerable<AddEventTagDto> eventTags);
    Task<bool> DeleteEventTagAsync(int eventId, IEnumerable<int> tagsIds);
}