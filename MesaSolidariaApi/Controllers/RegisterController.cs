using MassTransit;
using MesaSolidariaApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MesaSolidariaApi.Controllers;

[ApiController]
[Route("/Pedido")]
public class RegisterController : ControllerBase
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;
    
    public RegisterController(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _configuration = configuration;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var nomeFila = _configuration.GetSection("MassTransitAzure")["Subscription"];
        var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));

        //await endpoint.Send(new Pedido(1, new Usuario(2,"bolovo", "Justen")));
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> PostPacketsReceived()
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> PostIndividualProducts()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCompleteOrdersQueue()
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStorageUpdated()
    {
        return Ok();
    }
}