using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class DonationRequestModel : PageModel
{
    public Package PackageRequested { get; set; }
    public Delivery DeliveryRequested { get; set; }
}