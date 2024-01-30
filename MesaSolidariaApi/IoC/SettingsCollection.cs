using MassTransit;
using MesaSolidariaApi.Core.Services;
using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace MesaSolidariaApi.IoC;

public static class SettingsCollection
{
    public static void AddDataBaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(configuration.GetConnectionString("Connection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Connection")));
        });
    }

    public static void AddPubSubConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(configuration.GetSection("MassTransitAzure")["PubSubConnection"] ?? string.Empty);

                cfg.ConfigureEndpoints(context);
            });
        });
    }

    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IDonationService, DonationService>();
    }
}