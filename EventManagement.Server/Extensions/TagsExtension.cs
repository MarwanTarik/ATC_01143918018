using EventManagement.Server.Dtos.Event;
using EventManagement.Server.Models;

namespace EventManagement.Server.Extentions;

public static class TagsExtension
{
    public static TagDto ToDto(this Tags tag)
    {
        return new TagDto(
            TagId: tag.Id,
            TagName: tag.Tag
        );
    }
    
    public static Tags ToModel(this TagDto tag)
    {
        return new Tags
        {
            Id = tag.TagId,
            Tag = tag.TagName
        };
    }
}