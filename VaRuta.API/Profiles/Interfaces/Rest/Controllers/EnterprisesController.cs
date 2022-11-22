using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Profiles.Domain.Models;
using VaRuta.API.Profiles.Domain.Services;
using VaRuta.API.Profiles.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.Profiles.Interfaces.Rest.Controllers;

public class EnterprisesController : ControllerBase
{
   
private readonly IEnterpriseService _enterpriseService;
    private readonly IMapper _mapper;

    public EnterprisesController(IEnterpriseService enterpriseService, IMapper mapper)
    {
        _enterpriseService = enterpriseService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<EnterpriseResource>> GetAllAsync()
    {
        var enterprise = await _enterpriseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseResource>>(enterprise);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveEnterpriseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var enterprise = _mapper.Map<SaveEnterpriseResource, Enterprise>(resource);
        var result = await _enterpriseService.SaveAsync(enterprise);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var enterpriseResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);
        return Created(nameof(PostAsync), enterpriseResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEnterpriseResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var enterprise = _mapper.Map<SaveEnterpriseResource, Enterprise>(resource);
        var result = await _enterpriseService.UpdateAsync(id, enterprise);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var enterpriseResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);
        return Ok(enterpriseResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _enterpriseService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var enterpriseResource = _mapper.Map<Enterprise, EnterpriseResource>(result.Resource);
        return Ok(enterpriseResource);
    } 
}