using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Pages.Register;
using Microsoft.AspNetCore.Mvc;

namespace MesaSolidariaApi.Controllers;

public class RegisterController : Controller
{
    private readonly IDonationService _donationService;

    public RegisterController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    /// <summary>
    /// Página inicial
    /// </summary>
    /// <returns></returns>
    public IActionResult Acknowledgment()
    {
        return View();
    } 

    /// <summary>
    /// Direciona para a página do formulário de registro de produtos para doaçao
    /// </summary>
    /// <returns></returns>
    public IActionResult SubmitProducts()
    {
        return View(new SubmitProductsModel());
    }

    /// <summary>
    /// Valida o formulário de registro de pacotes para doaçao e manda para a fila
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SubmitProducts(SubmitProductsModel model)
    {
        if (ModelState.IsValid)
        {
            await _donationService.SendMessageToServiceBus(new Message
            {
                MessageType = MessageType.ProductsReceived,
                Product = new Product
                {
                    Donator = model.Donator,
                    Rice = model.Rice,
                    Bean = model.Bean,
                    Oil = model.Oil
                }
            });
            
            return RedirectToAction("Acknowledgment");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de envio do formulário inválida.");
            
            return RedirectToAction("SubmitProducts");
        }
    }
    
    /// <summary>
    /// Direciona para a página do formulário de registro de pacotes para doaçao
    /// </summary>
    /// <returns></returns>
    public IActionResult SubmitPackages()
    {
        return View(new SubmitPackagesModel());
    }

    /// <summary>
    /// Valida o formulário de registro de pacotes para doaçao e manda para a fila
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SubmitPackages(SubmitPackagesModel model)
    {
        if (ModelState.IsValid)
        {
            await _donationService.SendMessageToServiceBus(new Message
            {
                MessageType = MessageType.PackageReceived,
                Product = new Product
                {
                    Donator = model.Donator,
                    Rice = model.Rice,
                    Bean = model.Bean,
                    Oil = model.Oil
                }
            });
            return RedirectToAction("Acknowledgment");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de envio do formulário inválida.");
            return RedirectToAction("SubmitPackages");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCompleteOrdersQueue()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetStorageUpdated()
    {
        return Ok();
    }
}