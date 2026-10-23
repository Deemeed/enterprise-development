using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Infrastructure.InMemory;

internal class CarInMemoryRepository : IRepository<Car, int>
{
    private readonly List<Car> _cars = [];

    public Task<Car> Create(Car entity)
    {
        _cars.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(int entityId)
    {
        var car = Read(entityId).Result;
        if (car == null)
            return Task.FromResult(false);

        var result = _cars.Remove(car);
        return Task.FromResult(result);
    }

    public Task<List<Car>> GetAll()
    {
        return Task.FromResult(_cars.ToList());
    }

    public Task<Car?> Read(int entityId)
    {
        var car = _cars.FirstOrDefault(c => c.Id == entityId);
        return Task.FromResult(car);
    }

    public Task<Car> Update(Car entity)
    {
        Delete(entity.Id);
        Create(entity);
        return Task.FromResult(entity);
    }
}
