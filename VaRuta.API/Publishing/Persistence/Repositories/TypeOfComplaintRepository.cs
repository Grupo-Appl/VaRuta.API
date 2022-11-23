using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



namespace VaRuta.API.Publishing.Persistence.Repositories;

public class TypeOfComplaintRepository: BaseRepository, ITypeOfComplaintRepository
{
    public TypeOfComplaintRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TypeOfComplaint>> ListAsync()
    {
        return await _context.TypeOfComplaint.ToListAsync();
    }

    public async Task AddAsync(TypeOfComplaint typeOfComplaint)
    {
        await _context.TypeOfComplaint.AddAsync(typeOfComplaint);
    }

    public async Task<TypeOfComplaint> FindByIdAsync(int id)
    {
        return await _context.TypeOfComplaint.FindAsync(id);
    }

    public void Update(TypeOfComplaint typeOfComplaint)
    {
        _context.TypeOfComplaint.Update(typeOfComplaint);
    }

    public void Remove(TypeOfComplaint typeOfComplaint)
    {
        _context.TypeOfComplaint.Remove(typeOfComplaint);
    }
}