using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerraMobility.Wordlist.Domain.Contracts;

namespace VerraMobility.Wordlist.Domain;

public static class ServiceRegistration
{
    public static void AddDomainWordlist(
        this IServiceCollection services,
        string assemblyDomain)
    {
        Assembly assembly = Assembly.Load(assemblyDomain);
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientDomainWordlist))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}