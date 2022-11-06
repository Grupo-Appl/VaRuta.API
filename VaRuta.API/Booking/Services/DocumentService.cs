using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Booking.Services;

public class DocumentService : IDocumentService
{
    
    private readonly IDocumentRepository _documentRepository; 
    private readonly IUnitOfWork _unitOfWork;

    public DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork)
    {
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Document>> ListAsync()
    {
        return await _documentRepository.ListAsync();
    }

    public async Task<DocumentResponse> SaveAsync(Document document)
    {
        try
        {
            await _documentRepository.AddAsync(document);
            await _unitOfWork.CompleteAsync();
            return new DocumentResponse(document);
        }
        catch (Exception e)
        {
            return new DocumentResponse($"An error occurred while saving the document: {e.Message}");
        }
    }

    public async Task<DocumentResponse> UpdateAsync(int id, Document document)
    {
        var existingDocument = await _documentRepository.FindByIdAsync(id);

        if (existingDocument == null)
            return new DocumentResponse("Document not found.");

        existingDocument.Name = document.Name;

        try
        {
            _documentRepository.Update(existingDocument);
            await _unitOfWork.CompleteAsync();

            return new DocumentResponse(existingDocument);
        }
        catch (Exception e)
        {
            return new DocumentResponse($"An error occurred while updating the document: {e.Message}");
        }
    }

    public async Task<DocumentResponse> DeleteAsync(int id)
    {
        var existingDocument = await _documentRepository.FindByIdAsync(id);

        if (existingDocument == null)
            return new DocumentResponse("Document not found.");

        try
        {
            _documentRepository.Remove(existingDocument);
            await _unitOfWork.CompleteAsync();

            return new DocumentResponse(existingDocument);

        }
        catch (Exception e)
        {
            return new DocumentResponse($"An error occurred while deleting the document: {e.Message}");
        }
    }
	
}