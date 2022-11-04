using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationService _destinationService;
    private readonly IMapper _mapper;

    public DestinationsController(IDestinationService destinationService, IMapper mapper)
    {
        _destinationService = destinationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DestinationResource>> GetAllAsync()
    {
        var destination = await _destinationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Destination>, IEnumerable<DestinationResource>>(destination);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDestinationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var destination = _mapper.Map<SaveDestinationResource, Destination>(resource);
        var result = await _destinationService.SaveAsync(destination);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var destinationResource = _mapper.Map<Destination, DestinationResource>(result.Resource);
        return Created(nameof(PostAsync), destinationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDestinationResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var destination = _mapper.Map<SaveDestinationResource, Destination>(resource);
        var result = await _destinationService.UpdateAsync(id, destination);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var destinationResource = _mapper.Map<Destination, DestinationResource>(result.Resource);
        return Ok(destinationResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _destinationService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var destinationResource = _mapper.Map<Destination, DestinationResource>(result.Resource);
        return Ok(destinationResource);
    }
}