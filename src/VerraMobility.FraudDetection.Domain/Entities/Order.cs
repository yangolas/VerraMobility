using VerraMobility.FraudDetection.Domain.Enums;
using VerraMobility.FraudDetection.Domain.ValueObjects;

namespace VerraMobility.FraudDetection.Domain.Entities;

public class Order
{
    private static readonly string _incompletedState = $"Ey, Developer, the {nameof(Order)} is in state: {OrderState.Incompleted}, you can´t modify";
    public int OrderId { get; private set; }
    public int DealId { get; private set; }
    public string Email { get; private set; } = null!;
    public Address Address { get; private set; }
    public double CreditCard { get; private set; }
    public OrderState OrderState { get; private set; }

    public Order(int orderId)
    {
        SetOrderId(orderId);
        OrderState = OrderState.Incompleted;
    }

    public Order(
        int orderId,
        int dealId,
        string email,
        Address address,
        double creditCard)
    {
        SetOrderId(orderId);
        if (OrderState == OrderState.NotValid) return;
        SetDealId(dealId);
        if (OrderState == OrderState.NotValid) return;
        SetEmail(email);
        if (OrderState == OrderState.NotValid) return;
        SetAdress(address);
        if (OrderState == OrderState.NotValid) return;
        SetCreditCard(creditCard);
    }
    public void SetOrderId(int orderId)
    {
        CheckIfOrderIsInvalidState();
        VerifyIntInitialize(orderId);
        OrderId = orderId;
    }

    public void SetDealId(int dealId)
    {
        CheckIfOrderIsInvalidState();
        VerifyIntInitialize(dealId);
        DealId = dealId;
    }

    public void SetEmail(string email)
    {
        CheckIfOrderIsInvalidState();
        NormalizeEmail(ref email);
        Email = email;
    }

    public void SetAdress(Address address)
    {
        CheckIfOrderIsInvalidState();
        VerifyAdress(address);
        Address = address;
    }

    public void SetCreditCard(double creditCard)
    {
        CheckIfOrderIsInvalidState();
        //A este le falta verificacion pero como no se dice nada...
        VerifyDoubleInitialize(creditCard);
        CreditCard = creditCard;
    }

    public void SetOrderState(OrderState orderState)
    {
        CheckIfOrderIsInvalidState();
        OrderState = orderState;
    }

    private void VerifyIntInitialize(int id)
    {
        if (id <= 0)
            OrderState = OrderState.NotValid;
    }

    private void VerifyDoubleInitialize(double number)
    {
        if (number <= 0)
            OrderState = OrderState.NotValid;
    }

    private void VerifyAdress(Address address)
    {
        if (address.StatusAdress == StatusAdress.NotValid)
            OrderState = OrderState.NotValid;
    }

    private void NormalizeEmail(ref string email)
    {
        email = email.ToLower();
        IEnumerable<string> parts = email.Split('@').ToList();

        if (parts.Count() != 2)
        {
            OrderState = OrderState.NotValid;
            return;
        }

        string username = parts.First();
        string domain = parts.Last();

        int plusIndex = username.IndexOf('+');

        if (plusIndex >= 0)
            username = username.Substring(0, plusIndex);

        username = username.Replace(".", "");

        email = $"{username}@{domain}";
    }

    private void CheckIfOrderIsInvalidState() 
    {
        if (OrderState == OrderState.Incompleted)
            throw new ArgumentException(_incompletedState);

    }
}