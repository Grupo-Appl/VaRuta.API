using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]

public class TypeOfPackageController : ControllerBase
{ 
      
      
      private readonly ITypeOfPackageService _typeOfPackageService;
      private readonly IMapper _mapper;

      public TypeOfPackageController(ITypeOfPackageService typeOfPackageService, IMapper mapper)
      {
            _typeOfPackageService = typeOfPackageService;
            _mapper = mapper;
      }

      [HttpGet]
      public async Task<IEnumerable<TypeOfPackageResource>> GetAllAsync()
      {
            var typeOfPackage = await _typeOfPackageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TypeOfPackage>, IEnumerable<TypeOfPackageResource>>(typeOfPackage);
            return resources;
      }

      [HttpPost]
      public async Task<IActionResult> PostAsync([FromBody] SaveTypeOfPackageResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());

            var typeOfPackage = _mapper.Map<SaveTypeOfPackageResource, TypeOfPackage>(resource);
            var result = await _typeOfPackageService.SaveAsync(typeOfPackage);
            if (!result.Success)
                  return BadRequest(result.Message);
            var typeOfPackageResource = _mapper.Map<TypeOfPackage, TypeOfPackageResource>(result.Resource);
            return Created(nameof(PostAsync), typeOfPackageResource);

      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTypeOfPackageResource resource)
      {
            if (!ModelState.IsValid)
                  return BadRequest(ModelState.GetErrorMessages());
            
            var typeOfPackage = _mapper.Map<SaveTypeOfPackageResource, TypeOfPackage>(resource);
            var result = await _typeOfPackageService.UpdateAsync(id,typeOfPackage);
            if (!result.Success)
                  return BadRequest(result.Message);
            
            var typeOfPackageResource = _mapper.Map<TypeOfPackage, TypeOfPackageResource>(result.Resource);
            return Ok(typeOfPackageResource);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteAsync(int id)
      {
            var result = await _typeOfPackageService.DeleteAsync(id);
            if (!result.Success)
                  return BadRequest(result.Message);
            var typeOfPackageResource = _mapper.Map<TypeOfPackage, TypeOfPackageResource>(result.Resource);
            return Ok(typeOfPackageResource);

      }

}


