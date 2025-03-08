using Prueba2.Application.Models;
using Prueba2.Domain.Entities;

namespace Prueba2.Application.Mappers;

public static class Mapper_OrderLineDto_Domain
{
    public static IEnumerable<Order> MapToDomain(IEnumerable<OrderDto> ordersDto)
    {
        List<Order> orders = new();
        foreach (var orderDto in ordersDto)
        {
            orders.Add(
                new Order(
                    orderDto.OrderId,
                    orderDto.DealId,
                    orderDto.Email,
                    orderDto.Address,
                    orderDto.CreditCard
            ));
        }
        return orders;
    }
}