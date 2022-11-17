using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Domain.Services;
using VaRuta.API.Publishing.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Publishing.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TypeOfComplaintController: ControllerBase
{ 
      private readonly ITypeOfComplaintService _typeOfComplaintService;
    private readonly IMapper _mapper;

    public TypeOfComplaintController(ITypeOfComplaintService typeOfComplaintService, IMapper mapper)
    {
          _mapper = mapper;
          _typeOfComplaintService = typeOfComplaintService;
    }


    [HttpGet]
      public async Task<IEnumerable<TypeOfComplaintResource>> GetAllAsync()
      {
            var typeOfComplaint = await _typeOfComplaintService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TypeOfComplaint>, IEnumerable<TypeOfComplaintResource>>(typeOfComplaint);
            return resources;
      }

      [HttpPost]
      public async Task<IActionResult> PostAsync([FromBody] SaveTypeOfComplaintResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());
        
            var typeOfComplaint = _mapper.Map<SaveTypeOfComplaintResource, TypeOfComplaint>(resource);
            var result = await _typeOfComplaintService.SaveAsync(typeOfComplaint);
            if (!result.Success)
                  return BadRequest(result.Message);
        
            var typeOfComplaintResource = _mapper.Map<TypeOfComplaint, TypeOfComplaintResource>(result.Resource);
            return Created(nameof(PostAsync), typeOfComplaintResource);

      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTypeOfComplaintResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());
            
            var typeOfComplaint = _mapper.Map<SaveTypeOfComplaintResource, TypeOfComplaint>(resource);
            var result = await _typeOfComplaintService.UpdateAsync(id,typeOfComplaint);
            if (!result.Success)
                  return BadRequest(result.Message);
            
            var typeOfComplaintResource = _mapper.Map<TypeOfComplaint, TypeOfComplaintResource>(result.Resource);
            return Ok(typeOfComplaintResource);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteAsync(int id)
      {
            var result = await _typeOfComplaintService.DeleteAsync(id);
            if (!result.Success)
                  return BadRequest(result.Message);
            var typeOfComplaintResource = _mapper.Map<TypeOfComplaint, TypeOfComplaintResource>(result.Resource);
            return Ok(typeOfComplaintResource);

      }
}