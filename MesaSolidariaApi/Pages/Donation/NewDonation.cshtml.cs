using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class NewDonationModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}