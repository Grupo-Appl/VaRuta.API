using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services.Communication;

public class DocumentResponse : BaseResponse <Document>
{
    public DocumentResponse(string message) : base(message)
    {
    }

    public DocumentResponse(Document resource) : base(resource)
    {
    }
}