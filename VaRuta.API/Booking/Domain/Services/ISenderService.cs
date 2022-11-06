using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface ISenderService
{
    Task<IEnumerable<Sender>> ListAsync();
    Task<SenderResponse> SaveAsync(Sender sender);
    Task<SenderResponse> UpdateAsync(int id, Sender sender);
    Task<SenderResponse> RemoveAsync(int id);
}