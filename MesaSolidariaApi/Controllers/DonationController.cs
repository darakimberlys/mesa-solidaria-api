using MesaSolidariaApi.Core.Models;
using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Views.Donation;
using Microsoft.AspNetCore.Mvc;

namespace MesaSolidariaApi.Controllers;

public class DonationController : Controller
{
    private readonly IDonationService _donationService;

    public DonationController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    /// <summary>
    /// Página inicial
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
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
    /// Direcionamento para a página de login
    /// </summary>
    /// <returns></returns>
    public IActionResult NewDonation()
    {
        return View(new NewDonationModel());
    }

    [HttpPost]
    public async Task<IActionResult> PostNewDonationRequest()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PostDonationSuccess()
    {
        return Ok();
    }
    
    /// <summary>
    /// Direciona para a página do formulário de registro de produtos para doaçao
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult>  SubmitProducts()
    {
        return View(new SubmitProducts());
    }

    /// <summary>
    /// Valida o formulário de registro de pacotes para doaçao e manda para a fila
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SubmitProducts(SubmitProducts model)
    {
        if (ModelState.IsValid)
        {
            await _donationService.SendMessageToServiceBus(new Message
            {
                MessageType = MessageType.ProductsReceived,
                Product = new Product
                {
                    Donator = model.Product.Donator,
                    Rice = model.Product.Rice,
                    Bean = model.Product.Bean,
                    Oil = model.Product.Oil
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
                    Donator = model.Packages.Donator,
                    Rice = model.Packages.Rice,
                    Bean = model.Packages.Bean,
                    Oil = model.Packages.Oil
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
   
    public IActionResult Transparency()
    {
        return View(new TransparencyModel());
    }
    
    public IActionResult CompleteOrdersQueue()
    {
        return View(new CompleteOrdersQueueModel
        {
            //get all from database
        });
    }

    public IActionResult StorageUpdated()
    {
        return View(new StorageUpdatedModelModel
        {
            //get all from database
        });
    }
}