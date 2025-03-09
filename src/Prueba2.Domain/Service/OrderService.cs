using Prueba2.Domain.Contracts;
using Prueba2.Domain.Entities;
using Prueba2.Domain.Enums;

namespace Prueba2.Domain.Service;

public class OrderService : IOrderService
{
    //Esto realmente se suele meter en un dicionario con un codigo y ademas se crean excepciones customizadas...
    //pero depende mucho del enfoque que le de la empresa
    private const string Initialize = $"Ey, developer, you must initialize de collection of orders in {nameof(OrderService)}";
    private IEnumerable<Order>? _orders;

    public void LoadOrders(IEnumerable<Order> orders)
    {
        _orders = orders;
    }

    public IEnumerable<Order> GetOrdersValids()
    {
        if (_orders == null)
            throw new ArgumentNullException(Initialize);
        
        return _orders
            .Where(order => order.OrderState == OrderState.Valid)
            .Select(order => order);
    }
    public IEnumerable<int> GetIncompletedOrdersIdAscendant()
    {
        if (_orders == null)
            throw new ArgumentNullException(Initialize);

        return _orders
            .Where(order => order.OrderState == OrderState.Incompleted)
            .OrderBy(order => order.OrderId)
            .Select(order => order.OrderId);
    }

    public IEnumerable<int> GetInvalidOrdersIdAscendant()
    {
        if (_orders == null)
            throw new ArgumentNullException(Initialize);

        return _orders
            .Where(order => order.OrderState == OrderState.NotValid)
            .OrderBy(order => order.OrderId)
            .Select(order => order.OrderId);
    }
}