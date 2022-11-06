namespace VaRuta.API.Routing.Resources;

public class ShipmentResource
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int Freight { get; set; }
    public int Weight { get; set; }
    public string  Date { get; set; }
    public int DestinyId { get; set; }
}