using EventManagement.Server.Dtos.EventTags;
using EventManagement.Server.Models;

namespace EventManagement.Server.Extentions;

public static class EventTagsExtension
{
    public static EventTagDto ToDto(this EventTags eventTags)
    {
        return new EventTagDto
        (
            Id: eventTags.Id,
            EventId: eventTags.EventId,
            TagId: eventTags.TagId
        );
    }
    
    public static EventTags ToModel(this AddEventTagDto eventTagDto, int eventId)
    {
        return new EventTags
        {
            EventId = eventId,
            TagId = eventTagDto.TagId
        };
    }
}