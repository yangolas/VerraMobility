using Prueba2.Application.Models;
using Prueba2.Domain.Entities;
using Prueba2.Domain.Enums;
using Prueba2.Domain.ValueObjects;

namespace Prueba2.Application.Services;

public class OrderService : IOrderService
{
    private List<OrderDto> _ordersDto = null!;

    public void LoadLineOrderToObject(IEnumerable<string> inlinesOrders)
    {
        List<OrderDto> localOrders = new ();

        foreach (string inline in inlinesOrders) 
        {
            string[] fields = inline.Split(',');
            if (fields.Count() != 8)
            {
                localOrders.Add(new OrderDto
                {
                    OrderId = int.Parse(fields[0]),
                    OrderState = OrderState.NotValid,
                });
            }
            else 
            {
                localOrders.Add(new OrderDto
                {
                    OrderId = int.Parse(fields[0]),
                    DealId = int.Parse(fields[1]),
                    Email = fields[2],
                    Address = new Address(
                        street: fields[3],
                        city: fields[4],
                        state: fields[5],
                        zipCode: fields[6]
                    ),
                    CreditCard = double.Parse(fields[7]),
                });
            }
        }

        _ordersDto = localOrders;
    }

    public IEnumerable<OrderDto> GetOrdersToVerifyDomain() 
    {
        if (_ordersDto == null)
            throw new ArgumentException("Ey, developer, you must initialize de service");
        return _ordersDto
            .Where(order => order.OrderState == OrderState.Valid)
            .Select(order => order);
    }

    public IEnumerable<int> GetInvalidOrdersId(IEnumerable<Order> orders)
    {
        if (_ordersDto == null)
            throw new ArgumentException("Ey, developer, you must initialize de service");

        List<int> fraudulentsOrderIds =
        [
            .. orders
                .Where(order => order.OrderState == OrderState.NotValid)
                .Select(order => order.OrderId)
,
            .. _ordersDto
                .Where(order => order.OrderState == OrderState.NotValid)
                .Select(order => order.OrderId),
        ];

        return fraudulentsOrderIds;
    }
}