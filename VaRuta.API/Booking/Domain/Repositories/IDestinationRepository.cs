using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> ListAsync();
    Task AddAsync(Destination category);
    Task<Destination> FindByIdAsync(int id);
    void Update(Destination category);
    void Remove(Destination category);
}