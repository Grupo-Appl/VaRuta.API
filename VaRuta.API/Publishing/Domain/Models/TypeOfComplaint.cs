namespace VaRuta.API.Publishing.Domain.Models;

public class TypeOfComplaint
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Feedback> Feedback { get; set; }
}