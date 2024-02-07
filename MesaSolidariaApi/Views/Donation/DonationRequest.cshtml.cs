using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class DonationRequestModel : PageModel
{
    public Package PackageRequested { get; set; }
    public Delivery DeliveryRequested { get; set; }
}