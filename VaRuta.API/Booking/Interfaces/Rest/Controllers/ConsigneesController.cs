using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class ConsigneesController: ControllerBase
{
    private readonly IConsigneesService _consigneesService;
    private readonly IMapper _mapper;

    public ConsigneesController(IConsigneesService consigneesService, IMapper mapper)
    {
          _consigneesService = consigneesService;
          _mapper = mapper;
    }


    [HttpGet]
      public async Task<IEnumerable<ConsigneesResource>> GetAllAsync()
      {
            var consignees = await _consigneesService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Consignees>, IEnumerable<ConsigneesResource>>(consignees);
            return resources;
      }

      [HttpPost]
      public async Task<IActionResult> PostAsync([FromBody] SaveConsigneesResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());
        
            var consignee = _mapper.Map<SaveConsigneesResource, Consignees>(resource);
            var result = await _consigneesService.SaveAsync(consignee);
            if (!result.Success)
                  return BadRequest(result.Message);
        
            var consigneeResource = _mapper.Map<Consignees, ConsigneesResource>(result.Resource);
            return Created(nameof(PostAsync), consigneeResource);

      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutAsync(int id, [FromBody] SaveConsigneesResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());
            
            var consignee = _mapper.Map<SaveConsigneesResource, Consignees>(resource);
            var result = await _consigneesService.UpdateAsync(id,consignee);
            if (!result.Success)
                  return BadRequest(result.Message);
            
            var consigneeResource = _mapper.Map<Consignees, ConsigneesResource>(result.Resource);
            return Ok(consigneeResource);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteAsync(int id)
      {
            var result = await _consigneesService.DeleteAsync(id);
            if (!result.Success)
                  return BadRequest(result.Message);
            var consigneeResource = _mapper.Map<Consignees, ConsigneesResource>(result.Resource);
            return Ok(consigneeResource);

      }
}