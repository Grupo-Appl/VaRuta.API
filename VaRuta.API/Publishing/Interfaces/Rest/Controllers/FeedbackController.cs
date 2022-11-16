using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Publishing.Domain;
using VaRuta.API.Publishing.Domain.Services;
using VaRuta.API.Publishing.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Publishing.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class FeedbackController :ControllerBase
{
    private readonly IFeedbackService _feedbackService;
    private readonly IMapper _mapper;
    
    public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
    {
        _feedbackService = feedbackService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<FeedbackResource>> GetAllAsync()
    {
        var feedback = await _feedbackService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Feedback>, IEnumerable<FeedbackResource>>(feedback);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveFeedbackResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var feedback = _mapper.Map<SaveFeedbackResource, Feedback>(resource);
        var result = await _feedbackService.SaveAsync(feedback);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var feedbackResource = _mapper.Map<Feedback, FeedbackResource>(result.Resource);
        return Created(nameof(PostAsync), feedbackResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFeedbackResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var feedback = _mapper.Map<SaveFeedbackResource, Feedback >(resource);
        var result = await _feedbackService.UpdateAsync(id, feedback);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var feedbackResource = _mapper.Map<Feedback, DocumentResource>(result.Resource);
        return Ok(feedbackResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _feedbackService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var documentResource = _mapper.Map<Feedback, DocumentResource>(result.Resource);
        return Ok(documentResource);
    }
}