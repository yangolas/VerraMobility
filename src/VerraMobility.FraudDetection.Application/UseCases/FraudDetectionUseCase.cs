using VerraMobility.FraudDetection.Application.Contracts;
using VerraMobility.FraudDetection.Application.Mappers;
using VerraMobility.FraudDetection.Domain.Contracts;
using VerraMobility.FraudDetection.Domain.Entities;

namespace VerraMobility.FraudDetection.Application.UseCases;

public class FraudDetectionUseCase : IFraudDetectionUseCase
{
    IOrderService _orderService;
    IOrderComparerService _orderComparerService;

    public FraudDetectionUseCase(
        IOrderService orderService,
        IOrderComparerService orderComparerService)
    {
        _orderService = orderService;
        _orderComparerService = orderComparerService;
    }

    public async Task ExecuteFraudDetectionAsync(IEnumerable<string> inlineOrders)
    {
        IEnumerable<Order> allOrders = await Mapper_InlineOrder_Order.MapToDomainAsync(inlineOrders);
        _orderService.LoadOrders(allOrders);
        IEnumerable<Order> ordersValidToProcess = _orderService.GetOrdersValids();
        _orderComparerService.FraudulentCreditCardByAddressIdDeal(ref ordersValidToProcess);
        _orderComparerService.FraudulentCreditCardByEmailIdDeal(ref ordersValidToProcess);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        Console.WriteLine($"\n#############Exercise two############");
        Console.WriteLine($"Incompleted => {string.Join(", ", incompletedOrderIds)}");
        Console.WriteLine($"Fraudulents => {string.Join(", ", fraudulentsOrderIds)}");
    }
}