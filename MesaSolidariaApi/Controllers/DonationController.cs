using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MesaSolidariaApi.Controllers;

[ApiController]
[Route("/Doacao")]
public class DonationController : ControllerBase
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;
    
    public DonationController(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> PostNewDonationRequest()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PostDonationSuccess()
    {
        return Ok();
    }

}
