using Carwash.Domain;
using Carwash.Domain.Entities;
using Carwash.Application.Contracts;
using Carwash.Application.Contracts.Orders;

namespace Carwash.Application.Services;

internal class OrderService(IRepository<Order, int> orderRepository) : IApplicationService<OrderDto, OrderCreateUpdateDto, int>
{
    public async Task<OrderDto> Create(OrderCreateUpdateDto dto)
    {
        var order = Mapper.Map(dto);

        var result = await orderRepository.Create(order);

        return Mapper.Map(result);
    }

    public async Task<bool> Delete(int id) => await orderRepository.Delete(id);

    public async Task<OrderDto?> Read(int id)
    {
        var order = await orderRepository.Read(id);

        if (order == null)
            return null;

        return Mapper.Map(order);
    }

    public async Task<IList<OrderDto>> ReadAll() => Mapper.Map(await orderRepository.ReadAll());

    public async Task<OrderDto> Update(OrderCreateUpdateDto dto, int id)
    {
        var order = Mapper.Map(dto);
        order.Id = id;

        var result = await orderRepository.Update(order);

        return Mapper.Map(result);
    }
}
