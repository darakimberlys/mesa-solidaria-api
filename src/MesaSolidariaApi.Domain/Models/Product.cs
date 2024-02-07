namespace MesaSolidariaApi.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Donator { get; set; }
    public int Rice { get; set; }
    public int Bean { get; set; }
    public int Oil { get; set; }
    public DateTime LastUpdate { get; set; }
}