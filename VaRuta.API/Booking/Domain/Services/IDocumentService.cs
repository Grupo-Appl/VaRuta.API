using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services.Communication;

namespace VaRuta.API.Booking.Domain.Services;

public interface IDocumentService
{
    Task<IEnumerable<Document>> ListAsync();
    Task<DocumentResponse> SaveAsync(Document document);
    Task<DocumentResponse> UpdateAsync(int id, Document document);
    Task<DocumentResponse> DeleteAsync(int id);	
}