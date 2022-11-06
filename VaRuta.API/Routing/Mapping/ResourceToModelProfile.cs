using AutoMapper;
using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Resources;

namespace VaRuta.API.Routing.Mapping;

public class ResourceToModelProfile  : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShipmentResource, Shipment>();
    }
}