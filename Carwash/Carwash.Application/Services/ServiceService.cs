using Carwash.Domain;
using Carwash.Domain.Entities;
using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Services;

namespace Carwash.Application.Services;

internal class ServiceService(IRepository<Service, int> serviceRepository) : IApplicationService<ServiceDto, ServiceCreateUpdateDto, int>
{
    public async Task<ServiceDto> Create(ServiceCreateUpdateDto dto)
    {
        var service = Mapper.Map(dto);

        var result = await serviceRepository.Create(service);

        return Mapper.Map(result);
    }

    public async Task<bool> Delete(int id) => await serviceRepository.Delete(id);

    public async Task<ServiceDto?> Read(int id)
    {
        var service = await serviceRepository.Read(id);

        if (service == null)
            return null;

        return Mapper.Map(service);
    }

    public async Task<IList<ServiceDto>> ReadAll() => Mapper.Map(await serviceRepository.ReadAll());

    public async Task<ServiceDto> Update(ServiceCreateUpdateDto dto, int id)
    {
        var service = Mapper.Map(dto);
        service.Id = id;

        var result = await serviceRepository.Update(service);

        return Mapper.Map(result);
    }
}
