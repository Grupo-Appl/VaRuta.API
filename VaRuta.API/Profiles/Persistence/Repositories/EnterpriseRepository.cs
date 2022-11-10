using Microsoft.EntityFrameworkCore;
using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Profiles.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Profiles.Persistence.Repositories;

public class EnterpriseRepository : BaseRepository, IEnterpriseRepository
{
    public EnterpriseRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Enterprise>> ListAsync()
    {
        return await _context.Enterprises.ToListAsync();
    }

    public async Task AddAsync(Enterprise enterprise)
    {
        await _context.Enterprises.AddAsync(enterprise);
    }

    public async Task<Enterprise> FindByIdAsync(int id)
    {
        return await _context.Enterprises.FindAsync(id);
    }

    public void Update(Enterprise enterprise)
    {
        _context.Enterprises.Update(enterprise);
    }

    public void Remove(Enterprise enterprise)
    {
        _context.Enterprises.Remove(enterprise);
    }
}