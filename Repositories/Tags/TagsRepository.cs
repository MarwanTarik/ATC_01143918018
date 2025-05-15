using EventManagement.Server.Data;
using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Repositories.Tags;

public class TagsRepository(ApplicationDbContext context) : Repository(context), ITagsRepository
{
    private readonly DbSet<Models.Tags> _dbSet = context.Set<Models.Tags>();
    
    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        var tags = await _dbSet
            .AsNoTracking()
            .ToListAsync();

        return tags.Select(t => t.ToDto());
    }

    public async Task<TagDto?> GetTagByIdAsync(int tagId)
    {
        var tag = await _dbSet
            .FirstOrDefaultAsync(t => t.Id == tagId);

        return tag?.ToDto();
    }
}