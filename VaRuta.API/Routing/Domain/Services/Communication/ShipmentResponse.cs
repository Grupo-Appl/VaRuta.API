using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Routing.Domain.Services.Communication;

public class ShipmentResponse : BaseResponse <Shipment>
{
    public ShipmentResponse(string message) : base(message)
    {
    }

    public ShipmentResponse(Shipment resource) : base(resource)
    {
    }
}