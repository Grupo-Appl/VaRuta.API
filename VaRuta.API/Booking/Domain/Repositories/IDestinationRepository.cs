using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> ListAsync();
    Task AddAsync(Destination destination);
    Task<Destination> FindByIdAsync(int id);
    void Update(Destination destination);
    void Remove(Destination destination);
}