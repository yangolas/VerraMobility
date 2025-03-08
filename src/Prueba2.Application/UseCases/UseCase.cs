using Microsoft.Extensions.Logging;
using Prueba2.Application.Contracts;
using Prueba2.Application.Mappers;
using Prueba2.Application.Models;
using Prueba2.Domain.Entities;
using Prueba2.Domain.Service;

namespace Prueba2.Application.UseCases;

public class UseCase2 : IUseCase2
{
    //IResultado2Repository _resultado2Repository;
    //IUnitOfWorkRepository _unitOfWorkRepository;
    Services.IOrderService _orderServiceDto;
    IOrderComparerService _orderComparerService;
    ILogger<UseCase2> _logger;

    public UseCase2(
        Services.IOrderService orderServiceDto,
        IOrderComparerService orderComparerService,
        ILogger<UseCase2> logger)
        //IUnitOfWorkRepository unitOfWorkRepository,
        //IResultado2Repository resultado2Repository)
    {
        _logger = logger;
        _orderServiceDto = orderServiceDto;
        _orderComparerService = orderComparerService;
        //_resultado2Repository = resultado2Repository;
        //_unitOfWorkRepository = unitOfWorkRepository;
    }

    public void ExecutePrueba2(IEnumerable<string> inlineOrders)
    {
        _orderServiceDto.LoadLineOrderToObject(inlineOrders);
        IEnumerable<OrderDto> ordersToProccess = _orderServiceDto.GetOrdersToVerifyDomain();
        IEnumerable<Order> orders = Mapper_OrderLineDto_Domain.MapToDomain(ordersToProccess);
        _orderComparerService.EqualEmailIdDealsDifferentCreditsCards(orders);
        _orderComparerService.EqualAddressIdDealsDifferentCreditsCards(orders);
        IEnumerable<int> fraudulentsOrderIds = _orderServiceDto.GetInvalidOrdersId(orders);

        _logger.LogInformation(string.Join(", ",fraudulentsOrderIds));
        
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