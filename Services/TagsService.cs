using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Repositories.Events;
using EventManagement.Server.Repositories.Tags;

namespace EventManagement.Server.Services;

public class TagsService(ITagsRepository tagsRepository)
{
    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        return await tagsRepository
            .GetAllTagsAsync();
    }

    public async Task<TagDto?> GetTagByIdAsync(int tagId)
    {
        return await tagsRepository
            .GetTagByIdAsync(tagId);
    }
    
}