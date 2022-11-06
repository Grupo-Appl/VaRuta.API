using VaRuta.API.Routing.Domain.Models;

namespace VaRuta.API.Routing.Domain.Repositories;

public interface IShipmentRepository
{
    Task<IEnumerable<Shipment>> ListAsync();
    Task AddAsync(Shipment shipment);
    Task<Shipment> FindByIdAsync(int id);
    void Update(Shipment shipment);
    void Remove(Shipment shipment);
}