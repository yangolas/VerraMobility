using Microsoft.Extensions.DependencyInjection;
using Prueba1.Application.Contracts;
using Prueba1.Application.Model;
using Prueba2.Application.Contracts;
using Prueba2.Application.Models;

namespace Prueba1.Presentation;

public static class ExecuteUseCase
{
    private const string _initializeText = "Ey, Developer you must initialize service provider";
    private static IServiceProvider? _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider) 
    {
        IServiceScope scope = serviceProvider.CreateScope();
        _serviceProvider = scope.ServiceProvider;
    }

    public static async Task ExecutePrueba1()
    {
        if(_serviceProvider is null)
            throw new ArgumentNullException(_initializeText);
        IUseCase useCase = _serviceProvider.GetRequiredService<IUseCase>();

        await useCase.TextProcess();
    }

    public static async Task ExecutePrueba2(Prueba2Dto prueba2Dto)
    {
        if (_serviceProvider is null)
            throw new ArgumentNullException(_initializeText);

        IUseCase2 useCase2 = _serviceProvider.GetRequiredService<IUseCase2>();

        await useCase2.ExecutePrueba2(prueba2Dto);
    }
}