using EventManagement.Server.Data;

namespace EventManagement.Server.Repositories;

public class Repository(ApplicationDbContext context) : IRepository
{
    public async Task<int> SaveAsync()
    {
        var affected = await context.SaveChangesAsync();
        return affected;
    }
}