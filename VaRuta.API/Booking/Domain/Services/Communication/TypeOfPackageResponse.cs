using System.Runtime.CompilerServices;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;
namespace VaRuta.API.Booking.Domain.Services.Communication;

public class TypeOfPackageResponse : BaseResponse<TypeOfPackage>
{
    public TypeOfPackageResponse(string message) : base(message)
    {
    }

    public TypeOfPackageResponse(TypeOfPackage resource) : base(resource)
    {
    }
}