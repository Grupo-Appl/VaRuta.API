using System.ComponentModel.DataAnnotations;
using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Tracking.Resources;

public class SaveDeliveryResource
{
    [Required]
    public string  Date { get; set; }
    [MaxLength(150)]
    public string Description { get; set; }
    public int ShipmentId { get; set; }
}