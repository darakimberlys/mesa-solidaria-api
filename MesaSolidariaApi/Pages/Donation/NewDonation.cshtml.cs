using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Pages.Donation;

public class NewDonationModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}