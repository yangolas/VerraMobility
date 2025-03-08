using Microsoft.Extensions.DependencyInjection;
using Prueba2.Domain.Contracts;
using System.Reflection;

namespace Prueba2.Domain;

public static class ServiceRegistration
{
    public static void AddDomain2Service(
        this IServiceCollection services,
        string assemblyDomain2)
    {
        Assembly assembly = Assembly.Load(assemblyDomain2);
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