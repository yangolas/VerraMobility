using Prueba1.Application.Model;

namespace Prueba1.Application.Contracts;

public interface IUseCase : ITransientApplication
{
    Task ExecutePrueba1(Prueba1Dto prueba1Dto);
}