using EventManagement.Server.Data;

namespace EventManagement.Server.Repositories;

public class Repository(ApplicationDbContext context) : IRepository
{
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}