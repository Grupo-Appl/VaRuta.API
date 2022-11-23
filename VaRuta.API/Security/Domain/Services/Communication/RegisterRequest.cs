namespace VaRuta.API.Security.Domain.Services.Communication;

using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}