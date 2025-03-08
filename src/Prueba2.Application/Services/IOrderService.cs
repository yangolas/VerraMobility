using Prueba2.Application.Contracts;
using Prueba2.Application.Models;
using Prueba2.Domain.Entities;

namespace Prueba2.Application.Services;

public interface IOrderService : ITransientApplication
{
    void LoadLineOrderToObject(IEnumerable<string> inlinesOrders);

    IEnumerable<OrderDto> GetOrdersToVerifyDomain();

    IEnumerable<int> GetInvalidOrdersId(IEnumerable<Order> orders);
}