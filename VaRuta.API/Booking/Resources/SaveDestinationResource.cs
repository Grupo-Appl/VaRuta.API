using System.ComponentModel.DataAnnotations;
namespace VaRuta.API.Booking.Resources;
public class SaveDestinationResource
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
}