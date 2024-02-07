using MassTransit;
using MesaSolidariaApi.Core.Services;
using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Repository;
using MesaSolidariaApi.Repository.Repository;
using MesaSolidariaApi.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MesaSolidariaApi.IoC;

public static class SettingsCollection
{
    public static void AddDataBaseConnection(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(Environment.GetEnvironmentVariable("Connection"),
                ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("Connection")));
        });
    }

    public static void AddPubSubConfiguration(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(Environment.GetEnvironmentVariable("PubSubConnection") ?? string.Empty);

                cfg.ConfigureEndpoints(context);
            });
        });
    }

    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        serviceCollection.AddTransient<IDonationService, DonationService>();
    }
}