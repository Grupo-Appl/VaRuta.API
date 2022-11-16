using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Publishing.Resources;

public class SaveFeedbackResource
{
    
    [Required]
    public string date { get; set; }
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
}