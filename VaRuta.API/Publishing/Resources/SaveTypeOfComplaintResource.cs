using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Publishing.Resources;

public class SaveTypeOfComplaintResource
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
}