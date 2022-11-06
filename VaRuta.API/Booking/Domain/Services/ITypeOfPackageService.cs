using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface ITypeOfPackageService
{
    Task<IEnumerable<TypeOfPackage>>ListAsync();
    Task<TypeOfPackageResponse> SaveAsync(TypeOfPackage typeOfPackage);
    Task<TypeOfPackageResponse> UpdateAsync(int id, TypeOfPackage typeOfPackage);
    Task<TypeOfPackageResponse> DeleteAsync(int id);	
}