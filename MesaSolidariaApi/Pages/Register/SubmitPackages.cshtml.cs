using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Pages.Register;

public class SubmitPackagesModel : PageModel
{
    public string Donator { get; set; }
    public string PackageReference { get; set; }
    public int Rice { get; set; }
    public int Bean { get; set; }
    public int Oil { get; set; }
    public string DeliveryStatus { get; set; }
}