using Prueba1.Application.Model;
using Prueba1.Domain.Entities;

namespace Prueba1.Application.Mappers;

public static class Mapper_Prueba1Dto_Domain
{
    public static Entity MapToDomain(Prueba1Dto prueba1Dto)
    {
        return new Entity(
            prueba1Dto.ParametroInt,
            prueba1Dto.ParametroString);
    }
}