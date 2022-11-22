using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Booking.Resources;

public class SaveFreightResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Type { get; set; }
}