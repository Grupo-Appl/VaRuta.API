using VaRuta.API.Booking.Domain.Models;

namespace VaRuta.API.Booking.Domain.Repositories;

public interface IDocumentRepository
{
    Task<IEnumerable<Document>> ListAsync();
    Task AddAsync(Document document);
    Task<Document> FindByIdAsync(int id);
    void Update(Document document);
    void Remove(Document document);
}