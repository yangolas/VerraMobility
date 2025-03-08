using Prueba1.Repository.Models.EntitiesRepository;
using Prueba2.Domain.Entities;

namespace Prueba2.Application.Mappers;

public static class Mapper_Resultado2Repository_Domain
{
    public static Resultado2 MapToRepository(Entity entity)
    {
        return new Resultado2()
        {
            Id = entity.Id,
            Description = entity.ParametroString
        };
    }
}