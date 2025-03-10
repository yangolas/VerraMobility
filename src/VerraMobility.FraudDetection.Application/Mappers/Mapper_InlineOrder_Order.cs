using VerraMobility.FraudDetection.Domain.Entities;
using VerraMobility.FraudDetection.Domain.ValueObjects;

namespace VerraMobility.FraudDetection.Application.Mappers;

public static class Mapper_InlineOrder_Order
{
    public async static Task<IEnumerable<Order>> MapToDomainAsync(IEnumerable<string> inlinesOrders)
    {
        return await Task.Run(() =>
        {
            List<Order> localOrders = new();

            foreach (string inline in inlinesOrders)
            {
                string[] fields = inline.Split(',');
                if (fields.Length != 8)
                {
                    if (int.TryParse(fields[0], out int orderId))
                    {
                        localOrders.Add(new Order(
                            orderId: orderId
                        ));
                    }
                    else
                        continue;
                }
                else
                {
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
        });
    }
}