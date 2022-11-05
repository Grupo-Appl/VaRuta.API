using AutoMapper;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Resources;
namespace VaRuta.API.Booking.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap< Destination , DestinationResource>();
        CreateMap< Document , DocumentResource>();
    }
}