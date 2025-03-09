using Microsoft.Extensions.DependencyInjection;
using VerraMobility.FraudDetection.Application.Contracts;
using VerraMobility.Wordlist.Application.Contracts;

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

    public static async Task ExecuteWordlist()
    {
        if(_serviceProvider is null)
            throw new ArgumentNullException(_initializeText);
        IWordlistUseCase wordlist = _serviceProvider.GetRequiredService<IWordlistUseCase>();

        await wordlist.ExceuteWordlist();
    }

    public async static Task ExecuteFraudDetection(IEnumerable<string> inlineOrders)
    {
        if (_serviceProvider is null)
            throw new ArgumentNullException(_initializeText);

        IFraudDetectionUseCase fraudDetectionUseCase = _serviceProvider.GetRequiredService<IFraudDetectionUseCase>();

        await fraudDetectionUseCase.ExecuteFraudDetectionAsync(inlineOrders);
    }
}