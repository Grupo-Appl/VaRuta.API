using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface IConsigneesService
{
    Task<IEnumerable<Consignees>> ListAsync();
    Task<ConsigneesResponse> SaveAsync(Consignees consignees);
    Task<ConsigneesResponse> UpdateAsync(int id, Consignees consignees);
    Task<ConsigneesResponse> DeleteAsync(int id);
}