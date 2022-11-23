using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface IFreightRepository
{
    Task<IEnumerable<Freight>> ListAsync();
    Task AddAsync(Freight freight);
    Task<Freight> FindByIdAsync(int id);
    void Update(Freight freight);
    void Remove(Freight freight);
}