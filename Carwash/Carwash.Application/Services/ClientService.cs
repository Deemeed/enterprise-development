using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Clients;
using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над клиентами
/// </summary>
/// <param name="clientRepository">Репозиторий клиентов</param>
/// <param name="carRepository">Репозиторий автомобилей</param>
public class ClientService(IRepository<Client, int> clientRepository,
    IRepository<Car, int> carRepository) : IApplicationService<ClientDto, ClientCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<ClientDto> Create(ClientCreateUpdateDto dto)
    {
        var client = Mapper.Map(dto);

        var result = await clientRepository.Create(client);

        return Mapper.Map(result);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int id)
    {
        var client = await clientRepository.Read(id);
        if (client == null)
            return false;

        var cars = await carRepository.ReadAll();
        var clientCars = cars.Where(c => c.ClientId == id).ToList();

        foreach (var car in clientCars)
        {
            await carRepository.Delete(car.Id);
        }

        return await clientRepository.Delete(id);
    }

    /// <inheritdoc/>
    public async Task<ClientDto?> Read(int id)
    {
        var client = await clientRepository.Read(id);

        if (client == null)
            return null;

        return Mapper.Map(client);
    }

    /// <inheritdoc/>
    public async Task<IList<ClientDto>> ReadAll() => Mapper.Map(await clientRepository.ReadAll());

    /// <inheritdoc/>
    public async Task<ClientDto> Update(ClientCreateUpdateDto dto, int id)
    {
        var client = Mapper.Map(dto);
        client.Id = id;

        var result = await clientRepository.Update(client);

        return Mapper.Map(result);
    }
}
