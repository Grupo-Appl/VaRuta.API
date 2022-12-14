using AutoMapper;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Resources;

namespace VaRuta.API.Booking.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDestinationResource, Destination>();
    }
}