using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services.Communication;

public class SenderResponse : BaseResponse<Sender>
{
    public SenderResponse(string message) : base(message)
    {
    }

    public SenderResponse(Sender resource) : base(resource)
    {
    }
}