using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services.Communication;

public class DestinationResponse : BaseResponse<Destination>
{
    public DestinationResponse(string message) : base(message)
    {
    }

    public DestinationResponse(Destination resource) : base(resource)
    {
    }
}