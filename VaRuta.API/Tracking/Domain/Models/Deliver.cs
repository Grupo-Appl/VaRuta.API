using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Tracking.Domain.Models;

public class Deliver
{
    public int Id { get; set;}
    public string  Date { get; set; }
    public string Description { get; set; }
    public int ShipmentId { get; set; }
    
    public Shipment Shipment { get; set; }
    
}