using VerraMobility.FraudDetection.Domain.Contracts;
using VerraMobility.FraudDetection.Domain.Entities;
using VerraMobility.FraudDetection.Domain.Enums;

namespace VerraMobility.FraudDetection.Domain.Service;

public class OrderComparerService : IOrderComparerService
{
    public void FraudulentCreditCardByAddressIdDeal(ref IEnumerable<Order> orders)
    {
        var groupedFraudulentOrders = orders
            .GroupBy(order => new { order.Address, order.DealId })
            .Where(group => group.Select(order => order.CreditCard).Distinct().Count() > 1);

        foreach (var groupFraudulentOrder in groupedFraudulentOrders)
        {
            foreach (var order in groupFraudulentOrder)
            {
                order.OrderState = OrderState.NotValid;
            }
        }
    }

    public void FraudulentCreditCardByEmailIdDeal(ref IEnumerable<Order> orders)
    {
        var groupedFraudulentOrders = orders
            .GroupBy(order => new { order.Email, order.DealId })
            .Where(group => group.Select(order => order.CreditCard).Distinct().Count() > 1);

        foreach (var groupFraudulentOrder in groupedFraudulentOrders)
        {
            foreach (var order in groupFraudulentOrder)
            {
                order.OrderState = OrderState.NotValid;
            }
        }
    }
}