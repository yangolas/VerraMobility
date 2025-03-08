using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prueba1.Application;
using Prueba1.Domain;
using Prueba1.Presentation;
using Prueba1.Repository;
using Prueba1.Shared.Settings;
using Prueba2.Application;
using Prueba2.Application.Models;
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

await ExecuteUseCase.ExecutePrueba2(new Prueba2Dto()
{
    ParametroInt = 1,
    ParametroString = "example"
});

await host.StopAsync();
await host.WaitForShutdownAsync();