﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}