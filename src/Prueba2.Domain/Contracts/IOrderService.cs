using Prueba2.Domain.Entities;

namespace Prueba2.Domain.Contracts;

public interface IOrderService : ITransientDomain
{
    void LoadOrders(IEnumerable<Order> orders);
    IEnumerable<Order> GetOrdersValids();
    IEnumerable<int> GetIncompletedOrdersIdAscendant();
    IEnumerable<int> GetInvalidOrdersIdAscendant();
}