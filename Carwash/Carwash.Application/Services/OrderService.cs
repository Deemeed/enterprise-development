using Carwash.Domain;
using Carwash.Domain.Entities;
using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Orders;

namespace Carwash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над заказами
/// </summary>
/// <param name="orderRepository">Репозиторий заказов</param>
public class OrderService(IRepository<Order, int> orderRepository) : IApplicationService<OrderDto, OrderCreateUpdateDto, int>
{
    /// <inheritdoc/>
    public async Task<OrderDto> Create(OrderCreateUpdateDto dto)
    {
        var order = Mapper.Map(dto);

        var result = await orderRepository.Create(order);

        return Mapper.Map(result);
    }
    
    /// <inheritdoc/>
    public async Task<bool> Delete(int id) => await orderRepository.Delete(id);

    /// <inheritdoc/>
    public async Task<OrderDto?> Read(int id)
    {
        var order = await orderRepository.Read(id);

        if (order == null)
            return null;

        return Mapper.Map(order);
    }
    
    /// <inheritdoc/>
    public async Task<IList<OrderDto>> ReadAll() => Mapper.Map(await orderRepository.ReadAll());
    
    /// <inheritdoc/>
    public async Task<OrderDto> Update(OrderCreateUpdateDto dto, int id)
    {
        var order = Mapper.Map(dto);
        order.Id = id;

        var result = await orderRepository.Update(order);

        return Mapper.Map(result);
    }
}
