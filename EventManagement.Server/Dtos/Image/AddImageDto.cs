namespace EventManagement.Server.Dtos.Image;

public record AddImageDto (
    string Url,
    string ImageName,
    string ImageType);