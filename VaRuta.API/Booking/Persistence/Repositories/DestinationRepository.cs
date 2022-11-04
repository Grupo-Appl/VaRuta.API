using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VaRuta.API.Booking.Persistence.Repositories;

public class DestinationRepository : BaseRepository, IDestinationRepository
{
    public DestinationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Destination>> ListAsync()
    {
        return await _context.Destinations.ToListAsync();
    }

    public async Task AddAsync(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
    }

    public async Task<Destination> FindByIdAsync(int id)
    {
        return await _context.Destinations.FindAsync(id);
    }

    public void Update(Destination destination)
    {
        _context.Destinations.Update(destination);
    }

    public void Remove(Destination destination)
    {
        _context.Destinations.Remove(destination);
    }
}