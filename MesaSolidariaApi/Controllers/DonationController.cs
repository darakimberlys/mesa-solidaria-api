using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MesaSolidariaApi.Controllers;

public class DonationController : Controller
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public DonationController(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _configuration = configuration;
    }

    /// <summary>
    /// Direcionamento para a página de login
    /// </summary>
    /// <returns></returns>
    public IActionResult NewDonation()
    {
        return View(new NewDonationModel());
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