using Microsoft.Extensions.Logging;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.EntitiesRepository;
using Prueba2.Application.Contracts;
using Prueba2.Application.Mappers;
using Prueba2.Application.Models;
using Prueba2.Domain.Entities;
using System.Text.Json;

namespace Prueba2.Application.UseCases;

public class UseCase2 : IUseCase2
{
    IResultado2Repository _resultado2Repository;
    IUnitOfWorkRepository _unitOfWorkRepository;
    ILogger<UseCase2> _logger;
    public UseCase2(
        ILogger<UseCase2> logger,
        IUnitOfWorkRepository unitOfWorkRepository,
        IResultado2Repository resultado2Repository)
    {
        _logger = logger;
        _resultado2Repository = resultado2Repository;
        _unitOfWorkRepository = unitOfWorkRepository;
    }

    public async Task ExecutePrueba2(Prueba2Dto prueba1Dto)
    {
        Entity entity = Mapper_Prueba2Dto_Domain.MapToDomain(prueba1Dto);
        Resultado2 resultado = Mapper_Resultado2Repository_Domain.MapToRepository(entity);
        _resultado2Repository.CreateResultado(resultado);
        await _unitOfWorkRepository.SaveChangesAsync();
        //Esto lo hago ! porque se con seguridad de que existe en bd la entity de repositorio que he insertado dos lineas arriba
        Resultado2 responseDb = (await _resultado2Repository.GetByIdsync(resultado.Id))!;

        _logger.LogInformation("El resultado es:\n{Resultado}",
            JsonSerializer.Serialize(
                responseDb,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            )
        );

    }
}