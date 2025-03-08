using Prueba1.Application.Model;

namespace Prueba1.Application.Contracts;

public interface IUseCase : ITransientApplication
{
    Task TextProcess();
}