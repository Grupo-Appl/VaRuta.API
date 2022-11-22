using System.ComponentModel.DataAnnotations;

namespace VaRuta.API.Profiles.Resources;

public class SaveEnterpriseResource
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    [Required]
    [MaxLength(11)]
    public string Ruc { get; set; } 
    public string Mail { get; set; }
}