using VaRuta.API.Publishing.Domain.Models;

namespace VaRuta.API.Publishing.Domain.Repositories;

public interface ITypeOfComplaintRepository
{
    Task<IEnumerable<TypeOfComplaint>> ListAsync();
    Task AddAsync(TypeOfComplaint typeOfComplaint);
    Task<TypeOfComplaint> FindByIdAsync(int id);
    void Update(TypeOfComplaint typeOfComplaint);
    void Remove(TypeOfComplaint typeOfComplaint);
}