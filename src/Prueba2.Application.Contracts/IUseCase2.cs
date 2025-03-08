using Prueba2.Application.Models;

namespace Prueba2.Application.Contracts;

public interface IUseCase2 : ITransientApplication
{
    Task ExecutePrueba2(Prueba2Dto prueba2Dto);
}