using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Routing.Persistence.Repositories;

public class ShipmentRepository : BaseRepository, IShipmentRepository
{
    public ShipmentRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Shipment>> ListAsync()
    {
        return await _context.Shipments.ToListAsync();
    }

    public async Task AddAsync(Shipment shipment)
    {
        await _context.Shipments.AddAsync(shipment);
    }

    public async Task<Shipment> FindByIdAsync(int id)
    {
        return await _context.Shipments.FindAsync(id);
    }

    public void Update(Shipment shipment)
    {
        _context.Shipments.Update(shipment);
    }

    public void Remove(Shipment shipment)
    {
        _context.Shipments.Remove(shipment);
    }
}