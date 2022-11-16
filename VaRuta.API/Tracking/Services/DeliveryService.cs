using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Domain.Services;
using VaRuta.API.Tracking.Domain.Services.Communication;

namespace VaRuta.API.Tracking.Services;

public class DeliveryService : IDeliveryService
{
    private IDeliveryService _deliveryServiceImplementation;
    public Task<IEnumerable<Delivery>> ListAsync()
    {
        return _deliveryServiceImplementation.ListAsync();
    }

    public Task<DeliveryResponse> SaveAsync(Delivery delivery)
    {
        return _deliveryServiceImplementation.SaveAsync(delivery);
    }

    public Task<DeliveryResponse> UpdateAsync(int id, Delivery delivery)
    {
        return _deliveryServiceImplementation.UpdateAsync(id, delivery);
    }

    public Task<DeliveryResponse> DeleteAsync(int id)
    {
        return _deliveryServiceImplementation.DeleteAsync(id);
    }
}