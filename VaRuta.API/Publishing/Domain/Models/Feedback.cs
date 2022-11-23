using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Publishing.Domain;

public class Feedback
{
    public int Id { get; set; }
    public string date { get; set; }
    public string Description { get; set; }
    
    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
    
    public int TypeOfComplaintId { get; set; }
    public TypeOfComplaint TypeOfComplaint { get; set; }
    
}