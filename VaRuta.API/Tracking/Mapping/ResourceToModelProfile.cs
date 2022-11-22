using AutoMapper;
using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Resources;

namespace VaRuta.API.Tracking.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDeliveryResource, Delivery>();
    }
}