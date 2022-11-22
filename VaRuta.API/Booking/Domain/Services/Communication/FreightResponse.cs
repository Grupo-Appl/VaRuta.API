using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services.Communication;

public class FreightResponse  :BaseResponse <Freight>
{
    public FreightResponse(string message) : base(message)
    {
    }

    public FreightResponse(Freight resource) : base(resource)
    {
    }

}