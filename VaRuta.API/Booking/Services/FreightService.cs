using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Booking.Services;

public class FreightService : IFreightService
{
    
private readonly IFreightRepository _freightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FreightService(IFreightRepository freightRepository, IUnitOfWork unitOfWork)
    {
        _freightRepository = freightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Freight>> ListAsync()
    {
        return await _freightRepository.ListAsync();
    }

    public async Task<FreightResponse> SaveAsync(Freight freight)
    {
        try
        {
            await _freightRepository.AddAsync(freight);
            await _unitOfWork.CompleteAsync();
            return new FreightResponse(freight);
        }
        catch (Exception e)
        {
            return new FreightResponse($"An error occurred while saving the freight: {e.Message}");
        }
    }

    public async Task<FreightResponse> UpdateAsync(int id, Freight freight)
    {
        var existingFreight = await _freightRepository.FindByIdAsync(id);

        if (existingFreight == null)
            return new FreightResponse("Freight not found.");

        existingFreight.Name = freight.Name;

        try
        {
            _freightRepository.Update(existingFreight);
            await _unitOfWork.CompleteAsync();

            return new FreightResponse(existingFreight);
        }
        catch (Exception e)
        {
            return new FreightResponse($"An error occurred while updating the freight: {e.Message}");
        }
    }

    public async Task<FreightResponse> DeleteAsync(int id)
    {
        var existingFreight = await _freightRepository.FindByIdAsync(id);

        if (existingFreight == null)
            return new FreightResponse("Freight not found.");

        try
        {
            _freightRepository.Remove(existingFreight);
            await _unitOfWork.CompleteAsync();

            return new FreightResponse(existingFreight);
        }
        catch (Exception e)
        {
            return new FreightResponse($"An error occurred while deleting the freight: {e.Message}");
        }
    }
}