using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Domain.Services.Communication;

namespace VaRuta.API.Routing.Domain.Services;

public interface IShipmentService
{
    Task<IEnumerable<Shipment>> ListAsync();
    Task<ShipmentResponse> SaveAsync(Shipment shipment);
    Task<ShipmentResponse> UpdateAsync(int id, Shipment shipment);
    Task<ShipmentResponse> DeleteAsync(int id);	
}