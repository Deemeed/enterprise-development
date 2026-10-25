using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Infrastructure.InMemory;

internal class ServiceInMemoryRepository : IRepository<Service, int>
{
    private readonly List<Service> _services = [];
    private int _lastId = 1;

    public Task<Service> Create(Service entity)
    {
        entity.Id = _lastId++;
        _services.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(int entityId)
    {
        var service = Read(entityId).Result;
        if (service == null)
            return Task.FromResult(false);

        var result = _services.Remove(service);
        return Task.FromResult(result);
    }

    public Task<List<Service>> ReadAll()
    {
        return Task.FromResult(_services.ToList());
    }

    public Task<Service?> Read(int entityId)
    {
        var service = _services.FirstOrDefault(s => s.Id == entityId);
        return Task.FromResult(service);
    }

    public Task<Service> Update(Service entity)
    {
        Delete(entity.Id);
        Create(entity);
        return Task.FromResult(entity);
    }
}
