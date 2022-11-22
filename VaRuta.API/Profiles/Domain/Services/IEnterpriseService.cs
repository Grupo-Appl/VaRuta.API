using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Profiles.Domain.Services.Communication;

namespace VaRuta.API.Profiles.Domain.Services;

public interface IEnterpriseService
{
    Task<IEnumerable<Enterprise>> ListAsync();
    Task<EnterpriseResponse> SaveAsync(Enterprise enterprise);
    Task<EnterpriseResponse> UpdateAsync(int id, Enterprise enterprise);
    Task<EnterpriseResponse> DeleteAsync(int id);	
}