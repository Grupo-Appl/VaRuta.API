using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface IConsigneesRepository
{
    Task<IEnumerable<Consignees>> ListAsync();
    Task AddAsync(Consignees consignees);
    Task<Consignees> FindByIdAsync(int id);
    void Update(Consignees consignees);
    void Remove(Consignees consignees);
    
}