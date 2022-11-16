using AutoMapper;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Resources;

namespace VaRuta.API.Booking.Mapping;
public class ModelToResourceProfile :Profile
{
    public ModelToResourceProfile()
    {
        CreateMap< Destination , DestinationResource>();
        CreateMap<Sender, SenderResource>();
        CreateMap< Document , DocumentResource>();
        CreateMap< TypeOfPackage , TypeOfPackageResource>();
        CreateMap<Destination, DestinationResource>();
        CreateMap<Consignees, ConsigneesResource>();
        CreateMap<TypeOfComplaint, TypeOfComplaintResource>();
    }
}


