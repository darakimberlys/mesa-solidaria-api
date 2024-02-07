using MesaSolidariaApi.Core.Services.Interfaces;
using MesaSolidariaApi.Domain.Models;
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

    public async Task<IActionResult> DonationRequest()
    {
        return View(new DonationRequestModel());
    }
    
    /// <summary>
    /// Valida o formulário de registro de pacotes para doaçao e manda para a fila
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> DonationRequest(DonationRequestModel model)
    {
        if (ModelState.IsValid)
        {
            await _donationService.SendMessageToServiceBus(new Message
            {
                MessageType = MessageType.DonationRequest,
                Delivery = new Delivery
                {
                    Address = model.DeliveryRequested.Address,
                    CreatedAt = DateTime.Today,
                    Requester = model.DeliveryRequested.Requester
                },
                Package = new Package
                {
                    Bean = model.PackageRequested.Bean,
                    Oil = model.PackageRequested.Oil,
                    Rice = model.PackageRequested.Rice,
                    Requester = model.PackageRequested.Requester
                }
            });
            return RedirectToPage("Obrigado");
            
            return RedirectToAction("Acknowledgment");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de envio do formulário inválida.");
            
            return RedirectToAction("SubmitProducts");
        }
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

    public async Task<IActionResult> StorageUpdated()
    {
        var (product, dateBeans, dateRice, dateOil) = 
            await _donationService.GetActualStorage();
        
        return View(new StorageUpdatedModelModel
        {
            Product = new Product
            {
                Bean = product.Bean,
                Rice = product.Rice,
                Oil = product.Oil
            },
            BeanLastUpdate = dateBeans,
            RiceLastUpdate = dateRice,
            OilLastUpdate = dateOil
        });
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
}