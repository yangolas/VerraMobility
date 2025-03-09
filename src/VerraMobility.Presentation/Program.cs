using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prueba1.Presentation;
using VerraMobility.FraudDetection.Application;
using VerraMobility.FraudDetection.Domain;
using VerraMobility.Infraestructure.ReaderFiles;
using VerraMobility.Infraestructure.Repository;
using VerraMobility.Shared.Settings;
using VerraMobility.Wordlist.Application;
using VerraMobility.Wordlist.Domain;

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
servicesHost.AddReaderFileService(config.Assembly.AssemblyReaderFiles);
servicesHost.AddApplicationWordlist(config.Assembly.AssemblyApplicationWordlist);
servicesHost.AddApplicationFraudDetection(config.Assembly.AssemblyApplicationFraudDetection);
servicesHost.AddDomainWordlist(config.Assembly.AssemblyDomainWordlist);
servicesHost.AddDomainFraudDetection(config.Assembly.AssemblyDomainFraudDetection);
servicesHost.AddRepositoryContext(config.Database);
servicesHost.AddRepository(config.Assembly.AssemblyRepository);

IHost host = ConfigHost.CreateIocInHost(servicesHost);

ExecuteUseCase.Initialize(host.Services);

await ExecuteUseCase.ExecuteWordlist();

ExecuteUseCase.ExecuteFraudDetection(
    new List<string> 
    {
        "3",
        "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
        "2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321",
        "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
    }
);

await host.StopAsync();
await host.WaitForShutdownAsync();