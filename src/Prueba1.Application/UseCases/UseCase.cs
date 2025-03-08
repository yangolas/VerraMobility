using Microsoft.Extensions.Logging;
using Prueba1.Application.Contracts;
using Prueba1.Application.Mappers;
using Prueba1.Application.Model;
using Prueba1.Domain.Entities;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.EntitiesRepository;
using System.Text.Json;

namespace Prueba1.Application.Services;

public class UseCase : IUseCase
{
    IResultadoRepository _resultadoRepository;
    IUnitOfWorkRepository _unitOfWorkRepository;
    ILogger<UseCase> _logger;
    public UseCase(
        ILogger<UseCase> logger,
        IUnitOfWorkRepository unitOfWorkRepository,
        IResultadoRepository resultadoRepository)
    {
        _logger = logger;
        _resultadoRepository = resultadoRepository;
        _unitOfWorkRepository = unitOfWorkRepository;
    }

    public async Task ExecutePrueba1(Prueba1Dto prueba1Dto)
    {
        Entity entity = Mapper_Prueba1Dto_Domain.MapToDomain(prueba1Dto);
        Resultado resultado = Mapper_ResultadoRepository_Domain.MapToRepository(entity);
        _resultadoRepository.CreateResultado(resultado);
        await _unitOfWorkRepository.SaveChangesAsync();
        //Esto lo hago ! porque se con seguridad de que existe en bd la entity de repositorio que he insertado dos lineas arriba
        Resultado responseDb = (await _resultadoRepository.GetByIdsync(resultado.Id))!;

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