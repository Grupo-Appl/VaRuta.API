using AutoMapper;
using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Resources;

namespace VaRuta.API.Routing.Mapping;

public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap< Shipment , ShipmentResource>();
    }
}