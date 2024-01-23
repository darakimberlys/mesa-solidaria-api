namespace MesaSolidariaApi.Core.Models;

public class Delivery
{
    public string PackageReference { get; set; }
    public string Address { get; set; }
    public DateTime DeliveryPlannedDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string DeliveryStatus { get; set; }
}