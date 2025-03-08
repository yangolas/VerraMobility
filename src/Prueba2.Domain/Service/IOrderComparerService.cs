using Prueba2.Domain.Contracts;
using Prueba2.Domain.Entities;

namespace Prueba2.Domain.Service;

public interface IOrderComparerService : ITransientDomain
{
    public void EqualEmailIdDealsDifferentCreditsCards(IEnumerable<Order> orders);
    public void EqualAddressIdDealsDifferentCreditsCards(IEnumerable<Order> orders);
}