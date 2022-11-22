using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Shared.Extensions;
using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Domain.Services;
using VaRuta.API.Tracking.Resources;

namespace VaRuta.API.Tracking.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DeliveriesController : ControllerBase
{
    private readonly IDeliveryService _deliveryService;
    private readonly IMapper _mapper;

    public DeliveriesController(IDeliveryService deliveryService, IMapper mapper)
    {
        _deliveryService = deliveryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DeliveryResource>> GetAllAsync()
    {
        var delivery = await _deliveryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Delivery>, IEnumerable<DeliveryResource>>(delivery);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDeliveryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var delivery = _mapper.Map<SaveDeliveryResource, Delivery>(resource);
        var result = await _deliveryService.SaveAsync(delivery);
        if (!result.Success)
            return BadRequest(result.Message);

        var deliveryResource = _mapper.Map<Delivery, DeliveryResource>(result.Resource);
        return Created(nameof(PostAsync), deliveryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDeliveryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var delivery = _mapper.Map<SaveDeliveryResource, Delivery>(resource);
        var result = await _deliveryService.UpdateAsync(id, delivery);
        if (!result.Success)
            return BadRequest(result.Message);

        var deliveryResource = _mapper.Map<Delivery, DeliveryResource>(result.Resource);
        return Ok(deliveryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _deliveryService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var deliveryResource = _mapper.Map<Delivery, DeliveryResource>(result.Resource);
        return Ok(deliveryResource);
    }
}