using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Resources;
using VaRuta.API.Shared.Extensions;

namespace VaRuta.API.BookingCargo.Interfaces.Rest.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]

public class SenderController: ControllerBase
{

    private readonly ISenderService _senderService;
        private readonly IMapper _mapper;

        public SenderController(ISenderService senderService, IMapper mapper)
        {
            _senderService = senderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SenderResource>> GetAllSync()
        {
            var sender = await _senderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Sender>, IEnumerable<SenderResource>>(sender);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSenderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sender = _mapper.Map<SaveSenderResource, Sender>(resource);
            var result = await _senderService.SaveAsync(sender);
            if (!result.Success)
                return BadRequest(result.Message);

            var senderResource = _mapper.Map<Sender, SenderResource>(result.Resource);
            return Ok(senderResource);
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _senderService.RemoveAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var senderResource = _mapper.Map<Sender, SenderResource>(result.Resource);
            return Ok(senderResource);
        }
}