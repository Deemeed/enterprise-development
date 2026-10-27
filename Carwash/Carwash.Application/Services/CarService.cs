using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Cars;
using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над автомобилями
/// </summary>
/// <param name="carRepository">Репозиторий автомобилей</param>
/// <param name="clientRepository">Репозиторий клиентов</param>
public class CarService(IRepository<Car, int> carRepository,
    IRepository<Client, int> clientRepository) : IApplicationService<CarDto, CarCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<CarDto> Create(CarCreateUpdateDto dto)
    {
        var client = await clientRepository.Read(dto.ClientId);
        if (client == null) throw new KeyNotFoundException($"Клиент с Id={dto.ClientId} не существует");

        var car = Mapper.Map(dto, client);

        var result = await carRepository.Create(car);

        client.Cars.Add(result);
        await clientRepository.Update(client);

        return Mapper.Map(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int id)
    {
        var car = await carRepository.Read(id);
        if (car == null)
            return false;

        var client = await clientRepository.Read(car.ClientId);
        if (client != null)
        {
            client.Cars.RemoveAll(c => c.Id == id);
            await clientRepository.Update(client);
        }

        return await carRepository.Delete(id);
    }

    /// <inheritdoc/>
    public async Task<CarDto?> Read(int id)
    {
        var car = await carRepository.Read(id);

        if (car == null)
            return null;

        return Mapper.Map(car);
    }

    /// <inheritdoc/>
    public async Task<IList<CarDto>> ReadAll() => Mapper.Map(await carRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<CarDto> Update(CarCreateUpdateDto dto, int id)
    {
        var car = await carRepository.Read(id);
        if (car == null) throw new KeyNotFoundException($"Автомобиль с Id={id} не существует");
        var client = await clientRepository.Read(car.ClientId);
        if (client == null) throw new KeyNotFoundException($"Клиент с Id={car.ClientId} не существует");

        var potentiallyNewClient = await clientRepository.Read(dto.ClientId);
        if (potentiallyNewClient == null) throw new KeyNotFoundException($"Клиент с Id={dto.ClientId} не существует");

        var updatedCar = Mapper.Map(dto, potentiallyNewClient);
        updatedCar.Id = id;

        if (car.ClientId != dto.ClientId)
        {
            client.Cars.RemoveAll(c => c.Id == id);
            await clientRepository.Update(client);
            potentiallyNewClient.Cars.Add(updatedCar);
            await clientRepository.Update(potentiallyNewClient);
        }

        var result = await carRepository.Update(updatedCar);

        return Mapper.Map(result);
    }
}
