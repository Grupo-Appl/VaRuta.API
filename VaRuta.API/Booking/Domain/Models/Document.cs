using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Booking.Domain.Models;

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Shipment> Shipments { get; set; }
    
}