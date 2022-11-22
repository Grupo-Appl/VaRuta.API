using VaRuta.API.Tracking.Domain.Models;

namespace VaRuta.API.Tracking.Domain.Repositories;

public interface IDeliveryRepository
{
    Task<IEnumerable<Delivery>> ListAsync();
    Task AddAsync(Delivery delivery);
    Task<Delivery> FindByIdAsync(int id);
    void Update(Delivery delivery);
    void Remove(Delivery delivery);
}