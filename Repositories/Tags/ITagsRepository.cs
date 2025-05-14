using EventManagement.Server.Dtos.Event;

namespace EventManagement.Server.Repositories.Tags;

public interface ITagsRepository : IRepository
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto?> GetTagByIdAsync(int tagId);
}