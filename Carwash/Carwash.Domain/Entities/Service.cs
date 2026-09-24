using Carwash.Domain.Enums;

namespace Carwash.Domain.Entities;

/// <summary>
/// Класс услуги
/// </summary>
public class Service
{
    /// <summary>
    /// Уникальный идентификатор услуги
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название услуги
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Цена услуги
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Категория автомобиля, для которой предназначена услуга
    /// </summary>
    public required Category Category { get; set; }

    /// <summary>
    /// Продолжительность услуги в минутах
    /// </summary>
    public required int DurationInMinutes { get; set; }
}
