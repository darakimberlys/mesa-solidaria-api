using MassTransit;
using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MesaSolidariaApi.Core.Services;

public class DonationService : IDonationService
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public DonationService(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _configuration = configuration;
    }

    public async Task SendMessageToServiceBus(Message message)
    {
        var pubSub = Environment.GetEnvironmentVariable("Subscription");
        var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{pubSub}"));

        await endpoint.Send(message);
    }

    public void VerifyPackagesToAttendOrder()
    {
        
    }
}
