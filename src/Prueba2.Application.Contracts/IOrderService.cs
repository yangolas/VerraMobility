using Prueba2.Application.Models;

namespace Prueba2.Application.Contracts;

public interface IOrderService
{
    public IEnumerable<OrderDto> TransformInlineOrderToObject(IEnumerable<string> inlinesOrders);
}