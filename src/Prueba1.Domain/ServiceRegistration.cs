using Microsoft.Extensions.DependencyInjection;
using Prueba1.Domain.Contracts;
using System.Reflection;

namespace Prueba1.Domain;

public static class ServiceRegistration
{
    public static void AddDomainService(
        this IServiceCollection services,
        string assemblyDomain)
    {
        Assembly assembly = Assembly.Load(assemblyDomain);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientDomain))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}