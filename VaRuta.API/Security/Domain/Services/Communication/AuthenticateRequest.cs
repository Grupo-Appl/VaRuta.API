namespace VaRuta.API.Security.Domain.Services.Communication;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}