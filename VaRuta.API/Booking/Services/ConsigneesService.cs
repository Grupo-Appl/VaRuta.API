using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;


namespace VaRuta.API.Booking.Services;

public class ConsigneesService: IConsigneesService
{
    private readonly IConsigneesRepository _consigneesRepository; 
    private readonly IUnitOfWork _unitOfWork;

    public ConsigneesService(IConsigneesRepository consigneesRepository, IUnitOfWork unitOfWork)
    {
        _consigneesRepository = consigneesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Consignees>> ListAsync()
    {
        return await _consigneesRepository.ListAsync();
    }

    public async Task<ConsigneesResponse> SaveAsync(Consignees consignees)
    {
        try
        {
            await _consigneesRepository.AddAsync(consignees);
            await _unitOfWork.CompleteAsync();
            return new ConsigneesResponse(consignees);
        }
        catch (Exception e)
        {
            return new ConsigneesResponse($"An error occurred while saving the consignee: {e.Message}");
        }
    }

    public async Task<ConsigneesResponse> UpdateAsync(int id, Consignees consignees)
    {
        var existingConsignee = await _consigneesRepository.FindByIdAsync(id);

        if (existingConsignee == null)
            return new ConsigneesResponse("Consignee not found.");

        existingConsignee.Name = consignees.Name;

        try
        {
            _consigneesRepository.Update(existingConsignee);
            await _unitOfWork.CompleteAsync();

            return new ConsigneesResponse(existingConsignee);
        }
        catch (Exception e)
        {
            return new ConsigneesResponse($"An error occurred while updating the consignee: {e.Message}");
        }
    }

    public async Task<ConsigneesResponse> DeleteAsync(int id)
    {
        var existingConsignee = await _consigneesRepository.FindByIdAsync(id);

        if (existingConsignee == null)
            return new ConsigneesResponse("Consignee not found.");

        try
        {
            _consigneesRepository.Remove(existingConsignee);
            await _unitOfWork.CompleteAsync();

            return new ConsigneesResponse(existingConsignee);

        }
        catch (Exception e)
        {
            return new ConsigneesResponse($"An error occurred while deleting the consignee: {e.Message}");
        }
    }
}