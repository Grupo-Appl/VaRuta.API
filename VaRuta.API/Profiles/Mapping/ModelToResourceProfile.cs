using AutoMapper;
using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Profiles.Resources;

namespace VaRuta.API.Profiles.Mapping;

public class ModelToResourceProfile
{
    public ModelToResourceProfile()
    {
        CreateMap< Enterprise , EnterpriseResource>();
    }
}