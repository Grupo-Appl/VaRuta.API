using System.ComponentModel.DataAnnotations;
namespace VaRuta.API.Booking.Resources;

public class SaveTypeOfPackageResource
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
}