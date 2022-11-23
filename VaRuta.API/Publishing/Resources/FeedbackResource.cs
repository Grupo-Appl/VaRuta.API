namespace VaRuta.API.Publishing.Resources;

public class FeedbackResource
{
    public int Id { get; set; }
    public string date { get; set; }
    public string Description { get; set; }
    public int TypeOfComplaintId { get; set; }
    public int ShipmentId { get; set; }
}