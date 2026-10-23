using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Infrastructure.InMemory;

public class ClientInMemoryRepository : IRepository<Client, int>
{
    private readonly List<Client> _clients = [];

    public Task<Client> Create(Client entity)
    {
        _clients.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(int entityId)
    {
        var client = Read(entityId).Result;
        if (client == null)
            return Task.FromResult(false);

        var result = _clients.Remove(client);
        return Task.FromResult(result);
    }

    public Task<List<Client>> GetAll()
    {
        return Task.FromResult(_clients.ToList());
    }

    public Task<Client?> Read(int entityId)
    {
        var client = _clients.FirstOrDefault(c => c.Id == entityId);
        return Task.FromResult(client);
    }
        
    public Task<Client> Update(Client entity)
    {
        Delete(entity.Id);
        Create(entity);
        return Task.FromResult(entity);
    }
}
