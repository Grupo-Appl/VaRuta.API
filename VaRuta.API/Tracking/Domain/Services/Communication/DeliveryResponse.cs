using VaRuta.API.Shared.Domain.Services.Communication;
using VaRuta.API.Tracking.Domain.Models;

namespace VaRuta.API.Tracking.Domain.Services.Communication;

public class DeliveryResponse : BaseResponse <Delivery>
{
    public DeliveryResponse(string message) : base(message)
    {
    }

    public DeliveryResponse(Delivery resource) : base(resource)
    {
    }
}