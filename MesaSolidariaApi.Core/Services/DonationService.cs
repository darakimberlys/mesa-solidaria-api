using MassTransit;
using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Domain.Models;
using MesaSolidariaApi.Repository.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MesaSolidariaApi.Core.Services;

public class DonationService : IDonationService
{
    private readonly IBus _bus;
    private readonly IProductRepository _productRepository;

    public DonationService(IBus bus, IProductRepository productRepository)
    {
        _bus = bus;
        _productRepository = productRepository;
    }

    public async Task SendMessageToServiceBus(Message message)
    {
        var pubSub = Environment.GetEnvironmentVariable("Subscription");
        var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{pubSub}"));

        await endpoint.Send(message);
    }
    
    public async Task<(Product product, DateTime dateBeans, DateTime dateRice, DateTime dateOil)> GetActualStorage()
    {
        var product = new Product
        {
            Bean = await _productRepository.GetSumOfBeans(),
            Rice = await _productRepository.GetSumOfRice(),
            Oil = await _productRepository.GetSumOfOil()
        };

        var dateBeans = await _productRepository.GetLastUpdatedDateForBeans();
        var dateRice = await _productRepository.GetLastUpdatedDateForRice();
        var dateOil = await _productRepository.GetLastUpdatedDateForOil();

        return (product, dateBeans, dateRice, dateOil);
    }


    public void VerifyPackagesToAttendOrder()
    {
        
    }
}
