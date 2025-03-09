using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerraMobility.FraudDetection.Domain.Contracts;

namespace VerraMobility.FraudDetection.Domain;

public static class ServiceRegistration
{
    public static void AddDomainFraudDetection(
        this IServiceCollection services,
        string assemblyDomainFraudDetection)
    {
        Assembly assembly = Assembly.Load(assemblyDomainFraudDetection);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientDomainFraudDetection))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}