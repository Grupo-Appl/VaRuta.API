using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]

public class DocumentsController : ControllerBase
{
    
 private readonly IDocumentService _documentService;
    private readonly IMapper _mapper;

    public DocumentsController(IDocumentService documentService, IMapper mapper)
    {
        _documentService = documentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DocumentResource>> GetAllAsync()
    {
        var document = await _documentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Document>, IEnumerable<DocumentResource>>(document);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDocumentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var document = _mapper.Map<SaveDocumentResource, Document>(resource);
        var result = await _documentService.SaveAsync(document);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
        return Created(nameof(PostAsync), documentResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDocumentResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var document = _mapper.Map<SaveDocumentResource, Document>(resource);
        var result = await _documentService.UpdateAsync(id, document);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
        return Ok(documentResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _documentService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var documentResource = _mapper.Map<Document, DocumentResource>(result.Resource);
        return Ok(documentResource);
    }
}