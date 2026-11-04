namespace Carwash.Domain.Entities;

/// <summary>
/// Класс заказа
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный идентификатор заказа
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор клиента, сделавшего заказ
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Клиент, сделавший заказ
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Идентификатор автомобиля, для которого офрмляется заказ
    /// </summary>
    public required int CarId { get; set; }

    /// <summary>
    /// Автомобиль, для которой оформляется заказ
    /// </summary>
    public required Car Car { get; set; }

    /// <summary>
    /// Идентификатор услуги, для которой оформляется заказ
    /// </summary>
    public required int ServiceId { get; set; }

    /// <summary>
    /// Услуга, для которой оформляется заказ
    /// </summary>
    public required Service Service { get; set; }

    /// <summary>
    /// Номер бокса, в котором будет выполняться заказ
    /// </summary>
    public required int BoxNumber { get; set; }

    /// <summary>
    /// Дата и время начала заказа
    /// </summary>
    public required DateTime StartTime { get; set; }

    /// <summary>
    /// Дата и время окончания заказа
    /// </summary>
    public DateTime EndTime => StartTime.AddMinutes(Service.DurationInMinutes);
}
