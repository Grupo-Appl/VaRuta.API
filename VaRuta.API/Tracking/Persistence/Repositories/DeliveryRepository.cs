using Microsoft.EntityFrameworkCore;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;
using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Domain.Repositories;

namespace VaRuta.API.Tracking.Persistence.Repositories;

public class DeliveryRepository : BaseRepository, IDeliveryRepository
{
    public DeliveryRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Delivery>> ListAsync()
    {
        return await _context.Deliveries.ToListAsync();
    }

    public async Task AddAsync(Delivery delivery)
    {
        await _context.Deliveries.AddAsync(delivery);
    }

    public async Task<Delivery> FindByIdAsync(int id)
    {
        return await _context.Deliveries.FindAsync(id);
    }

    public void Update(Delivery delivery)
    {
        _context.Deliveries.Update(delivery);
    }

    public void Remove(Delivery delivery)
    {
        _context.Deliveries.Remove(delivery);
    }
}