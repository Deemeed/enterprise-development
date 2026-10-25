using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Infrastructure.InMemory;

/// <summary>
/// Имплементация репозитория для автомобилей
/// </summary>
public class CarInMemoryRepository : IRepository<Car, int>
{
    private readonly List<Car> _cars = [];
    private int _lastId = 1;

    /// <inheritdoc/>
    public Task<Car> Create(Car entity)
    {
        entity.Id = _lastId++;
        _cars.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<bool> Delete(int entityId)
    {
        var car = Read(entityId).Result;
        if (car == null)
            return Task.FromResult(false);

        var result = _cars.Remove(car);
        return Task.FromResult(result);
    }

    /// <inheritdoc/>
    public Task<List<Car>> ReadAll()
    {
        return Task.FromResult(_cars.ToList());
    }

    /// <inheritdoc/>
    public Task<Car?> Read(int entityId)
    {
        var car = _cars.FirstOrDefault(c => c.Id == entityId);
        return Task.FromResult(car);
    }

    /// <inheritdoc/>
    public Task<Car> Update(Car entity)
    {
        Delete(entity.Id);
        Create(entity);
        return Task.FromResult(entity);
    }
}
