namespace VaRuta.API.Tracking.Resources;

public class DeliveryResource
{
    public int Id { get; set;}
    public string  Date { get; set; }
    public string Description { get; set; }
    public int ShipmentId { get; set; }
}