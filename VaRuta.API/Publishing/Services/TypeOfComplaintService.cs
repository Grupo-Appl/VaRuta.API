using VaRuta.API.Publishing.Domain.Models;
using VaRuta.API.Publishing.Domain.Repositories;
using VaRuta.API.Publishing.Domain.Services;
using VaRuta.API.Publishing.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Publishing.Services;

public class TypeOfComplaintService: ITypeOfComplaintService
{
    private readonly ITypeOfComplaintRepository _typeOfComplaintRepository; 
    private readonly IUnitOfWork _unitOfWork;
    
    public TypeOfComplaintService(ITypeOfComplaintRepository typeOfComplaintRepository, IUnitOfWork unitOfWork)
    {
        _typeOfComplaintRepository = typeOfComplaintRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<TypeOfComplaint>> ListAsync()
    {
        return await _typeOfComplaintRepository.ListAsync();
    }

    public async Task<TypeOfComplaintResponse> SaveAsync(TypeOfComplaint typeOfComplaint)
    {
        try
        {
            await _typeOfComplaintRepository.AddAsync(typeOfComplaint);
            await _unitOfWork.CompleteAsync();
            return new TypeOfComplaintResponse(typeOfComplaint);
        }
        catch (Exception e)
        {
            return new TypeOfComplaintResponse($"An error occurred while saving the type of complaint: {e.Message}");
        }
    }

    public async Task<TypeOfComplaintResponse> UpdateAsync(int id, TypeOfComplaint typeOfComplaint)
    {
        var existingTypeOfComplaint = await _typeOfComplaintRepository.FindByIdAsync(id);

        if (existingTypeOfComplaint == null)
            return new TypeOfComplaintResponse("Type of complaint not found.");

        existingTypeOfComplaint.Name = typeOfComplaint.Name;

        try
        {
            _typeOfComplaintRepository.Update(existingTypeOfComplaint);
            await _unitOfWork.CompleteAsync();

            return new TypeOfComplaintResponse(existingTypeOfComplaint);
        }
        catch (Exception e)
        {
            return new TypeOfComplaintResponse($"An error occurred while updating the type of complaint: {e.Message}");
        }
    }

    public async Task<TypeOfComplaintResponse> DeleteAsync(int id)
    {
        var existingTypeOfComplaint = await _typeOfComplaintRepository.FindByIdAsync(id);

        if (existingTypeOfComplaint == null)
            return new TypeOfComplaintResponse("Type of complaint not found.");

        try
        {
            _typeOfComplaintRepository.Remove(existingTypeOfComplaint);
            await _unitOfWork.CompleteAsync();

            return new TypeOfComplaintResponse(existingTypeOfComplaint);

        }
        catch (Exception e)
        {
            return new TypeOfComplaintResponse($"An error occurred while deleting the type of complaint: {e.Message}");
        }
    }
}