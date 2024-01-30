using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class DonationRequestModel : PageModel
{
    private readonly IDonationService _donationService;
    
    public DonationRequestModel(IDonationService donationService)
    {
        _donationService = donationService;
    }
    
    public Package PackageRequested { get; set; }
    public Delivery DeliveryRequested { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        RedirectToServiceBus(new Message
        {
            MessageType = MessageType.DonationRequest,
            Delivery = new Delivery
            {
                Address = DeliveryRequested.Address,
                CreatedAt = DateTime.Today,
                Requester = PackageRequested.Requester
            },
            Package = new Package
            {
                Bean = PackageRequested.Bean,
                Oil = PackageRequested.Oil,
                Rice = PackageRequested.Rice,
                Requester = PackageRequested.Requester
            }
        });
        return RedirectToPage("Obrigado");
    }

    private async Task RedirectToServiceBus(Message createdMessage)
    {
        await _donationService.SendMessageToServiceBus(createdMessage);
    }

}