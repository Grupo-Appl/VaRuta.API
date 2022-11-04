using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Booking.Services;

public class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _destinationRepository; 
    private readonly IUnitOfWork _unitOfWork;

    public DestinationService(IDestinationRepository destinationRepository, IUnitOfWork unitOfWork)
    {
        _destinationRepository = destinationRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Destination>> ListAsync()
    {
        return await _destinationRepository.ListAsync();
    }

    public async Task<DestinationResponse> SaveAsync(Destination destination)
    {
        try
        {
            await _destinationRepository.AddAsync(destination);
            await _unitOfWork.CompleteAsync();
            return new DestinationResponse(destination);
        }
        catch (Exception e)
        {
            return new DestinationResponse($"An error occurred while saving the destination: {e.Message}");
        }
    }

    public async Task<DestinationResponse> UpdateAsync(int id, Destination destination)
    {
        var existingDestination = await _destinationRepository.FindByIdAsync(id);

        if (existingDestination == null)
            return new DestinationResponse("Destination not found.");

        existingDestination.Name = destination.Name;

        try
        {
            _destinationRepository.Update(existingDestination);
            await _unitOfWork.CompleteAsync();

            return new DestinationResponse(existingDestination);
        }
        catch (Exception e)
        {
            return new DestinationResponse($"An error occurred while updating the destination: {e.Message}");
        }
    }

    public async Task<DestinationResponse> DeleteAsync(int id)
    {
        var existingDestination = await _destinationRepository.FindByIdAsync(id);

        if (existingDestination == null)
            return new DestinationResponse("Destination not found.");

        try
        {
            _destinationRepository.Remove(existingDestination);
            await _unitOfWork.CompleteAsync();

            return new DestinationResponse(existingDestination);

        }
        catch (Exception e)
        {
            return new DestinationResponse($"An error occurred while deleting the destination: {e.Message}");
        }
    }
	
}