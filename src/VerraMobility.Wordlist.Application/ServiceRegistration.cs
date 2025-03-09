using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerraMobility.Wordlist.Application.Contracts;

namespace VerraMobility.Wordlist.Application;

public static class ServiceRegistration
{
    public static void AddApplicationWordlist(
        this IServiceCollection services,
        string assemblyApplication)
    {
        Assembly assembly = Assembly.Load(assemblyApplication);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientApplicationWordlist))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}