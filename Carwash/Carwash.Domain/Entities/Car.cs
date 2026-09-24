namespace Carwash.Domain.Entities;

/// <summary>
/// Класс автомобиля
/// </summary>
public class Car
{
    /// <summary>
    /// Уникальный идентификатор автомобиля
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Государственный номер автомобиля
    /// </summary>
    public required string LicensePlate { get; set; }

    /// <summary>
    /// Марка автомобиля
    /// </summary>
    public required string Brand { get; set; }
}
