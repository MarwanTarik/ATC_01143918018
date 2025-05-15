using EventManagement.Server.Enums;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Seeders;

public static class TagsSeeder
{
    public static void SeedTags(this ModelBuilder modelBuilder)
    {
        foreach (var tag in Enum.GetValues<TagsEnum>())
        {
            modelBuilder.Entity<Models.Tags>().HasData(
                new Models.Tags { Id = (int)tag, Tag = tag.ToString()}
            );
        }
    }
}