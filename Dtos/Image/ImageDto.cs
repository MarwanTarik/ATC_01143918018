namespace EventManagement.Server.Dtos.Image;

public record ImageDto(
    int Id,
    string Url,
    string ImageName,
    string ImageType,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    int CreatedBy);