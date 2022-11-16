using AutoMapper;
using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Resources;

namespace VaRuta.API.Tracking.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap< Delivery , DeliveryResource>();
    }
}