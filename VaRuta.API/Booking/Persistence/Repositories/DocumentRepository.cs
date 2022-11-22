using Microsoft.EntityFrameworkCore;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Booking.Persistence.Repositories;

public class DocumentRepository  : BaseRepository, IDocumentRepository
{
    
    public DocumentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Document>> ListAsync()
    {
        return await _context.Documents.ToListAsync();
    }

    public async Task AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
    }

    public async Task<Document> FindByIdAsync(int id)
    {
        return await _context.Documents.FindAsync(id);
    }

    public void Update(Document document)
    {
        _context.Documents.Update(document);
    }

    public void Remove(Document document)
    {
        _context.Documents.Remove(document);
    }

}