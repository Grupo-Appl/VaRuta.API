using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Publishing.Domain;
using VaRuta.API.Tracking.Domain.Models;

namespace VaRuta.API.Routing.Domain.Models;

public class Shipment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int Freight { get; set; }
    public int Weight { get; set; }
    public string Date { get; set; }
    public int DestinyId { get; set; }
    public int ConsigneesId { get; set; }
    public int SenderId { get; set; }
    public int TypeOfPackageId { get; set; }

    public int DocumentId { get; set; }

    //public int FreightId { get; set; }
    public Consignees Consignees { get; set; }
    public Destination Destination { get; set; }
    public Document Document { get; set; }
    public Sender Sender { get; set; }
    public TypeOfPackage TypeOfPackage { get; set; }
    
    public List<Delivery> Delivery { get; set; }
    public List<Feedback> Feedback { get; set; }
}