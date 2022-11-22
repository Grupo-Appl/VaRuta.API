using AutoMapper;
using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Resources;
namespace VaRuta.API.Publishing.Mapping;
public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap< Feedback , FeedbackResource>();
        CreateMap<TypeOfComplaint, TypeOfComplaintResource>();
    }
}