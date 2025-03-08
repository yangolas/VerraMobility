using Prueba2.Application.Models;
using Prueba2.Domain.Entities;

namespace Prueba2.Application.Mappers;

public static class Mapper_Prueba2Dto_Domain
{
    public static Entity MapToDomain(Prueba2Dto prueba2Dto)
    {
        return new Entity(
            prueba2Dto.ParametroInt,
            prueba2Dto.ParametroString);
    }
}