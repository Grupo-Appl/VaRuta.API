using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Booking.Services;

public class SenderService : ISenderService
{
    private readonly ISenderRepository _senderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SenderService(ISenderRepository senderRepository, IUnitOfWork unitOfWork)
    {
        _senderRepository = senderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Sender>> ListAsync()
    {
        return await _senderRepository.ListAsync();
    }
    
    public async Task<SenderResponse> SaveAsync(Sender sender)
    {
        try
        {
            await _senderRepository.AddAsync(sender);
            await _unitOfWork.CompleteAsync();
            return new SenderResponse(sender);
        }
        catch (Exception e)
        {
            return new SenderResponse($"An error occurred while having the sender: {e.Message}");
        }
    }

    public async Task<SenderResponse> UpdateAsync(int id, Sender sender)
    {
        var existingSender = await _senderRepository.FindbyIdAsync(id);

        if (existingSender == null)
            return new SenderResponse("Sender not found");

        existingSender.name = sender.name;

        try
        {
            _senderRepository.Update(existingSender);
            await _unitOfWork.CompleteAsync();

            return new SenderResponse(existingSender);
        }
        catch (Exception e)
        {
            return new SenderResponse($"An error has occurred while updating the sender: {e.Message}");
        }
    }

    public  async Task<SenderResponse> RemoveAsync(int id)
    {
        var existingSender = await _senderRepository.FindbyIdAsync(id);

        if (existingSender == null)
            return new SenderResponse("Sender not found");

        try
        {
            _senderRepository.Remove(existingSender);
            await _unitOfWork.CompleteAsync();

            return new SenderResponse(existingSender);
        }
        catch (Exception e)
        {
            return new SenderResponse($"An error has occurred while removing the sender: {e.Message}");
        }
    }
}