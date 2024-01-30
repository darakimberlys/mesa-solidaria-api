using MesaSolidariaApi.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class SubmitPackagesModel : PageModel
{
    public Package Packages { get; set; }
}