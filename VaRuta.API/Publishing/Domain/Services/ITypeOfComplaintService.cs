using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Domain.Services.Communication;

namespace VaRuta.API.Publishing.Domain.Services;

public interface ITypeOfComplaintService
{
    Task<IEnumerable<TypeOfComplaint>> ListAsync();
    Task<TypeOfComplaintResponse> SaveAsync(TypeOfComplaint typeOfComplaint);
    Task<TypeOfComplaintResponse> UpdateAsync(int id, TypeOfComplaint typeOfComplaint);
    Task<TypeOfComplaintResponse> DeleteAsync(int id);
}