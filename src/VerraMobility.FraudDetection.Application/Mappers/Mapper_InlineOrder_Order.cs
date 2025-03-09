using VerraMobility.FraudDetection.Domain.Entities;
using VerraMobility.FraudDetection.Domain.ValueObjects;

namespace VerraMobility.FraudDetection.Application.Mappers;

public static class Mapper_InlineOrder_Order
{
    public static IEnumerable<Order> MapToDomain(IEnumerable<string> inlinesOrders)
    {
        List<Order> localOrders = [];

        foreach (string inline in inlinesOrders)
        {
            string[] fields = inline.Split(',');
            if (fields.Count() != 8)
            {
                localOrders.Add(new Order(
                    orderId: int.Parse(fields[0])
                ));
            }
            else
            {
                //supongo de buena fe que en los int parse se metera un numero dentro de rango
                localOrders.Add(new Order(
                    orderId: int.Parse(fields[0]),
                    dealId: int.Parse(fields[1]),
                    email: fields[2],
                    address: new Address(
                        street: fields[3],
                        city: fields[4],
                        state: fields[5],
                        zipCode: int.Parse(fields[6])
                    ),
                    creditCard: double.Parse(fields[7])
                ));
            }
        }

        return localOrders;
    }
}