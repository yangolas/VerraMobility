using Microsoft.Extensions.DependencyInjection;
using Prueba1.Application.Contracts;
using System.Reflection;

namespace Prueba1.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(
        this IServiceCollection services,
        string assemblyApplication) 
    {
        Assembly assembly = Assembly.Load(assemblyApplication);
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