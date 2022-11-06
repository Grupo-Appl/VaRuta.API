using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services.Communication;

public class ConsigneesResponse: BaseResponse<Consignees>
{
    public ConsigneesResponse(string message) : base(message)
    {
    }

    public ConsigneesResponse(Consignees resource) : base(resource)
    {
    }
}