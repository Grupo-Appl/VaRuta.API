using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Booking.Resources;

public class SaveDocumentResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}