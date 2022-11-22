using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Profiles.Domain.Services.Communication;

public class EnterpriseResponse : BaseResponse <Enterprise>
{
    public EnterpriseResponse(string message) : base(message)
    {
    }

    public EnterpriseResponse(Enterprise resource) : base(resource)
    {
    }
}