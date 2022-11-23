using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Domain.Services;
using VaRuta.API.Routing.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Routing.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class ShipmentsController : ControllerBase
{
    
private readonly IShipmentService _shipmentService;
    private readonly IMapper _mapper;

    public ShipmentsController(IShipmentService shipmentService, IMapper mapper)
    {
        _shipmentService = shipmentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ShipmentResource>> GetAllAsync()
    {
        var shipment = await _shipmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Shipment>, IEnumerable<ShipmentResource>>(shipment);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveShipmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var shipment = _mapper.Map<SaveShipmentResource, Shipment>(resource);
        var result = await _shipmentService.SaveAsync(shipment);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var shipmentResource = _mapper.Map<Shipment, ShipmentResource>(result.Resource);
        return Created(nameof(PostAsync), shipmentResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShipmentResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var shipment = _mapper.Map<SaveShipmentResource, Shipment>(resource);
        var result = await _shipmentService.UpdateAsync(id, shipment);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var shipmentResource = _mapper.Map<Shipment, ShipmentResource>(result.Resource);
        return Ok(shipmentResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shipmentService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var shipmentResource = _mapper.Map<Shipment, ShipmentResource>(result.Resource);
        return Ok(shipmentResource);
    }
}