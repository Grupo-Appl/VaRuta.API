using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface IDestinationService
{
    Task<IEnumerable<Destination>> ListAsync();
    Task<DestinationResponse> SaveAsync(Destination destination);
    Task<DestinationResponse> UpdateAsync(int id, Destination destination);
    Task<DestinationResponse> DeleteAsync(int id);	
}