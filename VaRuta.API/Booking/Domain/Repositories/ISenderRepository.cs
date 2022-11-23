using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface ISenderRepository
{
    Task<IEnumerable<Sender>> ListAsync();
    Task AddAsync(Sender sender);
    Task<Sender> FindbyIdAsync(int id);
    void Update(Sender sender);
    void Remove(Sender sender);
}