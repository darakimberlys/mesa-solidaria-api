using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Pages.Register;

public class SubmitProductsModel : PageModel
{
    public int Id { get; set; }
    public string Donator { get; set; }
    public int Rice { get; set; }
    public int Bean { get; set; }
    public int Oil { get; set; }
}