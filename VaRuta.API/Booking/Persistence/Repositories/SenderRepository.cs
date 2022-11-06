using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Booking.Persistence.Repositories;

public class SenderRepository : BaseRepository, ISenderRepository
{
    public SenderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Sender>> ListAsync()
    {
        return await _context.Senders.ToListAsync();
    }

    public async Task AddAsync(Sender sender)
    {
        await _context.Senders.AddAsync(sender);
    }

    public async Task<Sender> FindbyIdAsync(int id)
    {
        return await _context.Senders.FindAsync(id);
    }

    public void Update(Sender sender)
    {
        _context.Senders.Update(sender);
    }

    public void Remove(Sender sender)
    {
        _context.Senders.Remove(sender);
    }
}