using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prueba1.Application;
using Prueba1.Domain;
using Prueba1.Presentation;
using Prueba1.Repository;
using Prueba1.Shared.Settings;
using Prueba2.Application;
using Prueba2.Domain;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();
IConfigurationSection configurationSection = configuration.GetSection("Config");
AppSettings config = configurationSection.Get<AppSettings>()!;

IServiceCollection servicesHost = new ServiceCollection();
servicesHost.Configure<AppSettings>(configurationSection);
servicesHost.AddReaderTxtService(config.Assembly.AssemblyReaderTxt);
servicesHost.AddApplicationService(config.Assembly.AssemblyApplication);
servicesHost.AddApplicationService(config.Assembly.AssemblyApplication);
servicesHost.AddApplication2Service(config.Assembly.AssemblyApplication2);
servicesHost.AddDomainService(config.Assembly.AssemblyDomain);
servicesHost.AddDomain2Service(config.Assembly.AssemblyDomain2);
servicesHost.AddRepositoryContext(config.Database);
servicesHost.AddRepository(config.Assembly.AssemblyRepository);

IHost host = ConfigHost.CreateIocInHost(servicesHost);

ExecuteUseCase.Initialize(host.Services);

await ExecuteUseCase.ExecutePrueba1();

ExecuteUseCase.ExecutePrueba2(
    new List<string> 
    {
        "3",
        "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
        "22,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321",
        "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
    }
);

await host.StopAsync();
await host.WaitForShutdownAsync();