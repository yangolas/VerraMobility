using Prueba2.Domain.Enums;
using Prueba2.Domain.ValueObjects;

namespace Prueba2.Domain.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int DealId { get; set; }
    public string Email { get; set; } = null!;
    public Address Address{ get; set; }
    public double CreditCard { get; set; }
    public OrderState OrderState { get; set; }

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
        VerifyIntInitialize(orderId);
        OrderId = orderId;
    }

    public void SetDealId(int dealId)
    {
        VerifyIntInitialize(dealId);
        DealId = dealId;
    }

    public void SetEmail(string email)
    {
        NormalizeEmail(ref email);
        Email = email;
    }

    public void SetAdress(Address address)
    {
        VerifyAdress(address);
        Address = address;
    }

    public void SetCreditCard(double creditCard)
    {
        //A este le falta verificacion pero como no se dice nada...
        VerifyDoubleInitialize(creditCard);
        CreditCard = creditCard;
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
}