namespace MesaSolidariaApi.Core.Models;

public class Package
{
    public string PackageReference { get; set; }
    public int Rice { get; set; }
    public int Bean { get; set; }
    public int Oil { get; set; }
    public string DeliveryStatus { get; set; }
}