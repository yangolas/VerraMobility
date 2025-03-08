using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.Context;
using Prueba1.Shared.Settings.Models;
using System.Reflection;

namespace Prueba1.Repository;

public static class ServiceRegister
{
    public static void AddRepositoryContext(
        this IServiceCollection serviceCollection,
        DatabaseSettings databaseSettings)
    {
        //Esto se haria asi, pero como quiero que se ejecute en memoria y no en una bd sql server real, instanciare el in memory
        //serviceCollection.AddDbContext<SqlServerContext>(service =>
        //{
        //    service.UseSqlServer(databaseSettings.ConnectionString);
        //});
        serviceCollection.AddDbContext<SqlServerContext>(options =>
            options.UseInMemoryDatabase(databaseName: databaseSettings.ConnectionString)
        );
    }

    public static void AddRepository(
        this IServiceCollection serviceCollection,
        string assemblyRepository)
    {
        Assembly assembly = Assembly.Load(assemblyRepository);
        serviceCollection.Scan(scan =>
            scan.FromAssemblies(assembly)
            .AddClasses(clases =>
                clases.AssignableToAny(typeof(ITransientRepository))
            )
            .AsImplementedInterfaces()
            .WithTransientLifetime()
        );
    }
}