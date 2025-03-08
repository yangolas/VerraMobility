using Microsoft.Extensions.DependencyInjection;
using Prueba2.Application.Contracts;
using System.Reflection;

namespace Prueba2.Application;

public static class ServiceRegistration
{
    public static void AddApplication2Service(
        this IServiceCollection services,
        string assemblyApplication2)
    {
        Assembly assembly = Assembly.Load(assemblyApplication2);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientApplication))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}