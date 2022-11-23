using AutoMapper;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Resources;

namespace VaRuta.API.Booking.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDestinationResource, Destination>();

        CreateMap<SaveSenderResource, Sender>();

        CreateMap<SaveFreightResource, Freight>();
        CreateMap<SaveDocumentResource, Document>();
        CreateMap<SaveTypeOfPackageResource, TypeOfPackage>();
        CreateMap<SaveConsigneesResource, Consignees>();
        CreateMap<SaveTypeOfComplaintResource, TypeOfComplaint>();
    }
}