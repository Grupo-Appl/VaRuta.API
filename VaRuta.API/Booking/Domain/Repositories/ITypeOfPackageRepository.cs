using VaRuta.API.Booking.Domain.Models;
namespace VaRuta.API.Booking.Domain.Repositories;

public interface ITypeOfPackageRepository
{
    Task<IEnumerable<TypeOfPackage>> ListAsync();
    Task AddAsync(TypeOfPackage typeOfPackage);
    Task<TypeOfPackage> FindByIdAsync(int id);
    void Update(TypeOfPackage typeOfPackage);
    void Remove(TypeOfPackage typeOfPackage);
}