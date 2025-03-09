using VerraMobility.FraudDetection.Domain.Entities;

namespace VerraMobility.FraudDetection.Domain.Contracts;

public interface IOrderComparerService : ITransientDomainFraudDetection
{
    public void FraudulentCreditCardByAddressIdDeal(ref IEnumerable<Order> orders);
    public void FraudulentCreditCardByEmailIdDeal(ref IEnumerable<Order> orders);
}