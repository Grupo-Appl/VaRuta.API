using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;


namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class FreightsController :ControllerBase
{
    private readonly IFreightService _freightService;
       private readonly IMapper _mapper;
       
    public FreightsController(IFreightService freightService, IMapper mapper)
    {
        _freightService = freightService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<FreightResource>> GetAllAsync()
    {
        var freight = await _freightService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Freight>, IEnumerable<FreightResource>>(freight);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveFreightResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var freight = _mapper.Map<SaveFreightResource, Freight>(resource);
        var result = await _freightService.SaveAsync(freight);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var freightResource = _mapper.Map<Freight, FreightResource>(result.Resource);
        return Created(nameof(PostAsync), freightResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFreightResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var freight = _mapper.Map<SaveFreightResource, Freight>(resource);
        var result = await _freightService.UpdateAsync(id, freight);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var freightResource = _mapper.Map<Freight, FreightResource>(result.Resource);
        return Ok(freightResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _freightService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var freightResource = _mapper.Map<Freight, FreightResource>(result.Resource);
        return Ok(freightResource);
    }

}