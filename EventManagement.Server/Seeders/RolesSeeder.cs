using EventManagement.Server.Enums;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Server.Seeders;

public static class RolesSeeder
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        foreach (var role in Enum.GetValues<RolesEnum>())
        {
            modelBuilder.Entity<Models.Roles>().HasData(
                new Models.Roles { Id = (int)role, Role = role.ToString() }
            );
        }
    }
}