using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Booking.Persistence.Repositories;

public class FreightRepository : BaseRepository, IFreightRepository
{
    public FreightRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Freight>> ListAsync()
    {
        return await _context.Freights.ToListAsync();
    }

    public async Task AddAsync(Freight freight)
    {
        await _context.Freights.AddAsync(freight);
    }

    public async Task<Freight> FindByIdAsync(int id)
    {
        return await _context.Freights.FindAsync(id);
    }

    public void Update(Freight freight)
    {
        _context.Freights.Update(freight);
    }

    public void Remove(Freight freight)
    {
        _context.Freights.Remove(freight);
    }
}