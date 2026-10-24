using Carwash.Domain.Entities;
using Carwash.Application.Contracts.Clients;
using Carwash.Application.Contracts.Cars;
using Carwash.Application.Contracts.Services;
using Carwash.Application.Contracts.Orders;

namespace Carwash.Application;

public static class Mapper
{
    public static ClientDto Map(Client entity) => 
        new(entity.Id, entity.FullName, entity.PhoneNumber, [.. Map(entity.Cars)]);

    public static IList<ClientDto> Map(IList<Client> entities) => [.. entities.Select(Map)];

    public static OrderDto Map(Order entity) => 
        new(entity.Id, Map(entity.Client), Map(entity.Car), Map(entity.Service), entity.BoxNumber, entity.StartTime, entity.EndTime);

    public static IList<OrderDto> Map(IList<Order> entities) => [.. entities.Select(Map)];

    public static ServiceDto Map(Service entity) => 
        new(entity.Id, entity.Name, entity.Price, entity.Category, entity.DurationInMinutes);

    public static IList<ServiceDto> Map(IList<Service> entities) => [.. entities.Select(Map)];

    public static CarDto Map(Car entity) => 
        new(entity.Id, entity.LicensePlate, entity.Brand, entity.ClientId);

    public static IList<CarDto> Map(IList<Car> entities) => [.. entities.Select(Map)];

    public static Client Map(ClientCreateUpdateDto dto) =>
        new() { Id = 0, FullName = dto.FullName, PhoneNumber = dto.PhoneNumber, Cars = [] };
    
    public static Car Map(CarCreateUpdateDto dto) =>
        new() { Id = 0, LicensePlate = dto.LicensePlate, Brand = dto.Brand, ClientId = dto.ClientId };

    public static Service Map(ServiceCreateUpdateDto dto) =>
        new() { Id = 0, Name = dto.Name, Price = dto.Price, Category = dto.Category, DurationInMinutes = dto.DurationInMinutes };

    public static Order Map(OrderCreateUpdateDto dto) =>
        new() { Id = 0, ClientId = dto.ClientId, CarId = dto.CarId, ServiceId = dto.ServiceId, BoxNumber = dto.BoxNumber, StartTime = dto.StartTime };
}
