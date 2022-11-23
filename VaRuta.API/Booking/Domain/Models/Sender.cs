using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Booking.Domain.Models;

public class Sender
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    
    public List<Shipment> Shipments { get; set; }
}