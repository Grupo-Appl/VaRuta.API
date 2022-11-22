
using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;
namespace VaRuta.API.Booking.Persistence.Repositories;

public class TypeOfPackageRepository : BaseRepository , ITypeOfPackageRepository
{
    public TypeOfPackageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TypeOfPackage>> ListAsync()
    {
        return await _context.TypeOfPackages.ToListAsync();
    }

    public async Task AddAsync(TypeOfPackage typeOfPackage)
    {
        await _context.TypeOfPackages.AddAsync(typeOfPackage);
    }
    public async Task<TypeOfPackage> FindByIdAsync(int id)
    {
        return await _context.TypeOfPackages.FindAsync(id);
    }

    public void Update(TypeOfPackage typeOfPackage)
    {
        _context.TypeOfPackages.Update(typeOfPackage);
    }

    public void Remove(TypeOfPackage typeOfPackage)
    {
        _context.TypeOfPackages.Remove(typeOfPackage);
    }


}
