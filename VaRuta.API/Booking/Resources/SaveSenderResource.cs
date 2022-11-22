using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Booking.Resources;

public class SaveSenderResource
{
    [Required]
    [MaxLength(100)]
    public string name { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string email { get; set; }
}