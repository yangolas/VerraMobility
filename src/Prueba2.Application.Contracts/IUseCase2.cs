namespace Prueba2.Application.Contracts;

public interface IUseCase2 : ITransientApplication
{
    void ExecutePrueba2(IEnumerable<string> inlineOrders);
}