using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Clients;
using Carwash.Domain;
using Carwash.Domain.Entities;

namespace Carwash.Application.Services;

public class ClientService(IRepository<Client, int> clientRepository) : IApplicationService<ClientDto, ClientCreateUpdateDto, int>
{
    public async Task<ClientDto> Create(ClientCreateUpdateDto dto)
    {
        var client = Mapper.Map(dto);

        var result = await clientRepository.Create(client);

        return Mapper.Map(result);
    }

    public async Task<bool> Delete(int id) => await clientRepository.Delete(id);

    public async Task<ClientDto?> Read(int id)
    {
        var client = await clientRepository.Read(id);

        if (client == null)
            return null;

        return Mapper.Map(client);
    }

    public async Task<IList<ClientDto>> ReadAll() => Mapper.Map(await clientRepository.ReadAll());

    public async Task<ClientDto> Update(ClientCreateUpdateDto dto, int id)
    {
        var client = Mapper.Map(dto);
        client.Id = id;

        var result = await clientRepository.Update(client);

        return Mapper.Map(result);
    }
}
