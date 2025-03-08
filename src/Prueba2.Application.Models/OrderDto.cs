using Prueba2.Domain.Enums;
using Prueba2.Domain.ValueObjects;

namespace Prueba2.Application.Models;

public class OrderDto
{
    public int OrderId { get; set; }
    public int DealId { get; set; }
    public string Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public double CreditCard { get; set; }
    public OrderState OrderState { get; set; }
}