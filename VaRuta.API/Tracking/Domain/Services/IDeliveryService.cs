using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Domain.Services.Communication;

namespace VaRuta.API.Tracking.Domain.Services;

public interface IDeliveryService
{
    Task<IEnumerable<Delivery>> ListAsync();
    Task<DeliveryResponse> SaveAsync(Delivery delivery);
    Task<DeliveryResponse> UpdateAsync(int id, Delivery delivery);
    Task<DeliveryResponse> DeleteAsync(int id);	
}