using System.Text.Json.Serialization;


namespace VaRuta.API.Security.Domain.Models;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
}