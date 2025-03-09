using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Prueba1.Presentation;

public static class ConfigHost
{
    public static IHost CreateIocInHost(IServiceCollection services)
    {
        IHost host = Host.CreateDefaultBuilder()
        .ConfigureServices(localServices =>
        {
            foreach (var service in services)
            {
                localServices.Add(service);
            }
        })
        .Build();
        return host;
    }
}