using MesaSolidariaApi.Domain.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MesaSolidariaApi.Views.Donation;

public class StorageUpdatedModelModel : PageModel
{
    public Product Product { get; set; }
    public DateTime RiceLastUpdate { get; set; }
    public DateTime BeanLastUpdate { get; set; }
    public DateTime OilLastUpdate { get; set; }
}