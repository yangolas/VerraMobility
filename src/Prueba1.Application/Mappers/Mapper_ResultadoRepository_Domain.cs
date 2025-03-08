using Prueba1.Domain.Entities;
using Prueba1.Repository.Models.EntitiesRepository;

namespace Prueba1.Application.Mappers;

public static class Mapper_ResultadoRepository_Domain
{
    public static Resultado MapToRepository(Entity entity)
    {
        return new Resultado() 
        { 
            Id = entity.Id,
            Description = entity.ParametroString
        };
    }
}