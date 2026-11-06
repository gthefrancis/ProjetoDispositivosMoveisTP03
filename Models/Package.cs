namespace RastreioEncomendas.Models;

public class Package
{
    public string PackageId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ShippingDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public string CurrentLocation { get; set; } = string.Empty;
    public List<TrackingEvent> Events { get; set; } = new();

    public string ShippingDateLabel => ShippingDate.ToString("dd/MM/yyyy");
    public string EstimatedDeliveryDateLabel => EstimatedDeliveryDate.ToString("dd/MM/yyyy");
}
