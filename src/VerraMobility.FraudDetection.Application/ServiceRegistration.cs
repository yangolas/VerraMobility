using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerraMobility.FraudDetection.Application.Contracts;

namespace VerraMobility.FraudDetection.Application;

public static class ServiceRegistration
{
    public static void AddApplicationFraudDetection(
        this IServiceCollection services,
        string assemblyApplicationFraudDetection)
    {
        Assembly assembly = Assembly.Load(assemblyApplicationFraudDetection);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientApplicationFraudDetection))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}