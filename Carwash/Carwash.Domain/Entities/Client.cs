namespace Carwash.Domain.Entities;

/// <summary>
/// Класс клиента
/// </summary>
public class Client
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Полное имя клиента
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Список автомобилей клиента
    /// </summary>
    public required List<Car> Cars { get; set; } = [];
}
