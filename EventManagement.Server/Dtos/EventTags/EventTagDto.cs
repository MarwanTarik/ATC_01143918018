namespace EventManagement.Server.Dtos.EventTags;

public record EventTagDto(
    int Id,
    int EventId,
    int TagId);