using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Booking.Resources;

public class SaveConsigneesResource
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    [Required]
    [MaxLength(8)]
    public string Dni { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    
}