using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
 

namespace VaRuta.API.Booking.Persistence.Repositories;

public class ConsigneeRepository: BaseRepository, IConsigneesRepository
{
    public ConsigneeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Consignees>> ListAsync()
    {
        return await _context.Consignees.ToListAsync();
    }

    public async Task AddAsync(Consignees consignees)
    {
        await _context.Consignees.AddAsync(consignees);
    }

    public async Task<Consignees> FindByIdAsync(int id)
    {
        return await _context.Consignees.FindAsync(id);
    }

    public void Update(Consignees consignees)
    {
        _context.Consignees.Update(consignees);
    }

    public void Remove(Consignees consignees)
    {
        _context.Consignees.Remove(consignees);
    }
}