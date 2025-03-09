using Prueba2.Domain.Entities;

namespace Prueba2.Domain.Contracts;

public interface IOrderComparerService : ITransientDomain
{
    public void FraudulentCreditCardByAddressIdDeal(ref IEnumerable<Order> orders);
    public void FraudulentCreditCardByEmailIdDeal(ref IEnumerable<Order> orders);
}