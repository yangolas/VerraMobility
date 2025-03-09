using Microsoft.Extensions.Logging;
using Prueba2.Application.Contracts;
using Prueba2.Application.Mappers;
using Prueba2.Domain.Contracts;
using Prueba2.Domain.Entities;

namespace Prueba2.Application.UseCases;

public class UseCase2 : IUseCase2
{
    //IResultado2Repository _resultado2Repository;
    //IUnitOfWorkRepository _unitOfWorkRepository;
    IOrderService _orderService;
    IOrderComparerService _orderComparerService;
    ILogger<UseCase2> _logger;

    public UseCase2(
        ILogger<UseCase2> logger,
        IOrderService orderService,
        IOrderComparerService orderComparerService)
        //IUnitOfWorkRepository unitOfWorkRepository,
        //IResultado2Repository resultado2Repository)
    {
        _logger = logger;
        _orderService = orderService;
        _orderComparerService = orderComparerService;
        //_resultado2Repository = resultado2Repository;
        //_unitOfWorkRepository = unitOfWorkRepository;
    }

    public void ExecutePrueba2(IEnumerable<string> inlineOrders)
    {
        IEnumerable<Order> allOrders = Mapper_InlineOrder_Domain.MapToDomain(inlineOrders);
        _orderService.LoadOrders(allOrders);
        IEnumerable<Order> ordersValidToProcess = _orderService.GetOrdersValids();
        _orderComparerService.FraudulentCreditCardByAddressIdDeal(ref ordersValidToProcess);
        _orderComparerService.FraudulentCreditCardByEmailIdDeal(ref ordersValidToProcess);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        Console.WriteLine($"\n#############Exercise two############");
        Console.WriteLine($"Incompleted => {string.Join(", ", incompletedOrderIds)}");
        Console.WriteLine($"Fraudulents => {string.Join(", ", fraudulentsOrderIds)}");
        //_logger.LogInformation(string.Join(", ", incompletedOrderIds));
        //_logger.LogInformation(string.Join(", ",fraudulentsOrderIds));
        
        //Resultado2 resultado = Mapper_Resultado2Repository_Domain.MapToRepository(entity);
        //_resultado2Repository.CreateResultado(resultado);
        //await _unitOfWorkRepository.SaveChangesAsync();
        ////Esto lo hago ! porque se con seguridad de que existe en bd la entity de repositorio que he insertado dos lineas arriba
        //Resultado2 responseDb = (await _resultado2Repository.GetByIdsync(resultado.Id))!;

        //_logger.LogInformation("El resultado es:\n{Resultado}",
        //    JsonSerializer.Serialize(
        //        responseDb,
        //        new JsonSerializerOptions
        //        {
        //            WriteIndented = true
        //        }
        //    )
        //);

    }
}