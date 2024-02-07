using MesaSolidariaApi.Domain.Models;

namespace MesaSolidariaApi.Core.Services.Interfaces;

public interface IDonationService
{
    Task SendMessageToServiceBus(Message message);
    Task<(Product product, DateTime dateBeans, DateTime dateRice, DateTime dateOil)> GetActualStorage();

}