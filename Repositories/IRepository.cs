namespace EventManagement.Server.Repositories;

public interface IRepository
{
    public Task<int> SaveAsync();
}