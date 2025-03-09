using VerraMobility.FraudDetection.Domain.Entities;

namespace VerraMobility.FraudDetection.Domain.Contracts;

public interface IOrderService : ITransientDomainFraudDetection
{
    void LoadOrders(IEnumerable<Order> orders);
    IEnumerable<Order> GetOrdersValids();
    IEnumerable<int> GetIncompletedOrdersIdAscendant();
    IEnumerable<int> GetInvalidOrdersIdAscendant();
}