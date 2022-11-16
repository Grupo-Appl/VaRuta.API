using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Publishing.Domain.Services.Communication;

public class TypeOfComplaintResponse: BaseResponse<TypeOfComplaint>
{
    public TypeOfComplaintResponse(string message) : base(message)
    {
    }

    public TypeOfComplaintResponse(TypeOfComplaint resource) : base(resource)
    {
    }
}