using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Prueba1.Application;

public static class ServiceRegistration
{
    public static void AddReaderTxtService(
        this IServiceCollection services,
        string assemblyReaderTxt) 
    {
        Assembly assembly = Assembly.Load(assemblyReaderTxt);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientReader))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}