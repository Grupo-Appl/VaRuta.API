using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface IFreightService
{
    Task<IEnumerable<Freight>> ListAsync();
    Task<FreightResponse> SaveAsync(Freight freight);
    Task<FreightResponse> UpdateAsync(int id, Freight freight);
    Task<FreightResponse> DeleteAsync(int id);	
}