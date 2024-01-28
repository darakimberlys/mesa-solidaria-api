using MesaSolidariaApi.Core.Models;

namespace MesaSolidariaApi.Core.Services.Interfaces;

public interface IDonationService
{
    Task SendMessageToServiceBus(Message message);
}