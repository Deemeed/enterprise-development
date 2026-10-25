using Carwash.Domain.Entities;
using Carwash.Application.Contracts.Clients;
using Carwash.Application.Contracts.Cars;
using Carwash.Application.Contracts.Services;
using Carwash.Application.Contracts.Orders;

namespace Carwash.Application;

/// <summary>
/// Класс с методами для маппинга сущностей в DTO и обратно
/// </summary>
public static class Mapper
{
    /// <summary>
    /// Преобразует объект Client в объект ClientDto.
    /// </summary>
    /// <param name="entity">Экземпляр Client для преобразования.</param>
    /// <returns>Экземпляр ClientDto, созданный на основе переданного объекта Client.</returns>
    public static ClientDto Map(Client entity) => 
        new(entity.Id, entity.FullName, entity.PhoneNumber, [.. Map(entity.Cars)]);

    /// <summary>
    /// Преобразует коллекцию сущностей Client в коллекцию объектов ClientDto.
    /// </summary>
    /// <param name="entities">Список сущностей Client для преобразования.</param>
    /// <returns>Список объектов ClientDto.</returns>
    public static IList<ClientDto> Map(IList<Client> entities) => [.. entities.Select(Map)];

    /// <summary>
    /// Преобразует объект Order в соответствующий объект OrderDto.
    /// </summary>
    /// <param name="entity">Экземпляр Order для преобразования.</param>
    /// <returns>OrderDto, представляющий указанный заказ.</returns>
    public static OrderDto Map(Order entity) => 
        new(entity.Id, Map(entity.Client), Map(entity.Car), Map(entity.Service), entity.BoxNumber, entity.StartTime, entity.EndTime);

    /// <summary>
    /// Преобразует коллекцию сущностей Order в коллекцию объектов OrderDto.
    /// </summary>
    /// <param name="entities">Список сущностей Order для преобразования.</param>
    /// <returns>Список объектов OrderDto.</returns>
    public static IList<OrderDto> Map(IList<Order> entities) => [.. entities.Select(Map)];

    /// <summary>
    /// Преобразует экземпляр Service в ServiceDto.
    /// </summary>
    /// <param name="entity">Экземпляр Service для преобразования.</param>
    /// <returns>Объект ServiceDto, созданный на основе переданного Service.</returns>
    public static ServiceDto Map(Service entity) => 
        new(entity.Id, entity.Name, entity.Price, entity.Category, entity.DurationInMinutes);

    /// <summary>
    /// Преобразует коллекцию сущностей Service в коллекцию объектов ServiceDto.
    /// </summary>
    /// <param name="entities">Список сущностей Service для преобразования.</param>
    /// <returns>Список объектов ServiceDto.</returns>
    public static IList<ServiceDto> Map(IList<Service> entities) => [.. entities.Select(Map)];

    /// <summary>
    /// Преобразует сущность Car в объект CarDto.
    /// </summary>
    /// <param name="entity">Сущность Car для преобразования.</param>
    /// <returns>Объект CarDto, созданный на основе переданной сущности.</returns>
    public static CarDto Map(Car entity) => 
        new(entity.Id, entity.LicensePlate, entity.Brand, entity.ClientId);

    /// <summary>
    /// Преобразует коллекцию сущностей Car в коллекцию объектов CarDto.
    /// </summary>
    /// <param name="entities">Список сущностей Car для преобразования.</param>
    /// <returns>Список объектов CarDto.</returns>
    public static IList<CarDto> Map(IList<Car> entities) => [.. entities.Select(Map)];

    /// <summary>
    /// Создает новый экземпляр Client на основе данных из ClientCreateUpdateDto.
    /// </summary>
    /// <param name="dto">Объект с данными для создания или обновления клиента.</param>
    /// <returns>Новый экземпляр Client с заполненными свойствами.</returns>
    public static Client Map(ClientCreateUpdateDto dto) =>
        new() { Id = 0, FullName = dto.FullName, PhoneNumber = dto.PhoneNumber, Cars = [] };
    
    /// <summary>
    /// Создает новый экземпляр Car на основе данных из CarCreateUpdateDto.
    /// </summary>
    /// <param name="dto">Объект с данными для создания или обновления автомобиля.</param>
    /// <returns>Новый экземпляр Car с заполненными свойствами.</returns>
    public static Car Map(CarCreateUpdateDto dto) =>
        new() { Id = 0, LicensePlate = dto.LicensePlate, Brand = dto.Brand, ClientId = dto.ClientId };

    /// <summary>
    /// Создает новый экземпляр Service на основе данных из ServiceCreateUpdateDto.
    /// </summary>
    /// <param name="dto">Объект с данными для создания или обновления услуги.</param>
    /// <returns>Новый экземпляр Service.</returns>
    public static Service Map(ServiceCreateUpdateDto dto) =>
        new() { Id = 0, Name = dto.Name, Price = dto.Price, Category = dto.Category, DurationInMinutes = dto.DurationInMinutes };

    /// <summary>
    /// Создает новый экземпляр Order на основе данных из OrderCreateUpdateDto.
    /// </summary>
    /// <param name="dto">Данные для создания или обновления заказа.</param>
    /// <returns>Новый экземпляр Order с заполненными свойствами.</returns>
    public static Order Map(OrderCreateUpdateDto dto) =>
        new() { Id = 0, ClientId = dto.ClientId, CarId = dto.CarId, ServiceId = dto.ServiceId, BoxNumber = dto.BoxNumber, StartTime = dto.StartTime };
}
