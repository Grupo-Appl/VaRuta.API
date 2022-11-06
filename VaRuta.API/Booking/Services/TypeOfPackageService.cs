using VaRuta.API.Booking.Domain.Models;
using VaRuta.API.Booking.Domain.Repositories;
using VaRuta.API.Booking.Domain.Services;
using VaRuta.API.Booking.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Booking.Services;

public class TypeOfPackageService : ITypeOfPackageService
{
    private readonly ITypeOfPackageRepository _typeOfPackageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TypeOfPackageService(ITypeOfPackageRepository typeOfPackageRepository, IUnitOfWork unitOfWork)
    {
        _typeOfPackageRepository = typeOfPackageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TypeOfPackage>> ListAsync()
    {
        return await _typeOfPackageRepository.ListAsync();
    }

    public async Task<TypeOfPackageResponse> SaveAsync(TypeOfPackage typeOfPackage)
    {
        try
        {
            await _typeOfPackageRepository.AddAsync((typeOfPackage));
            await _unitOfWork.CompleteAsync();
            return new TypeOfPackageResponse(typeOfPackage);
        }
        catch (Exception e)
        {
            return new TypeOfPackageResponse($"An error occurred while saving the package: {e.Message}");
        }
    }

    public async Task<TypeOfPackageResponse> UpdateAsync(int id, TypeOfPackage typeOfPackage)
    {
        var existingTypeOfPackage = await _typeOfPackageRepository.FindByIdAsync(id);

        if (existingTypeOfPackage == null)
            return new TypeOfPackageResponse("Package not found.");
        
        existingTypeOfPackage.Name = typeOfPackage.Name;

        try
        {
            _typeOfPackageRepository.Update(existingTypeOfPackage);
            await _unitOfWork.CompleteAsync();

            return new TypeOfPackageResponse(existingTypeOfPackage);
        }
        catch (Exception e)
        {
            return new TypeOfPackageResponse($"An error occurred while updating the Package: {e.Message}");
        }
    }

    public async Task<TypeOfPackageResponse> DeleteAsync(int id)
    {
        var existingTypeOfPackage = await _typeOfPackageRepository.FindByIdAsync(id);
        
        if (existingTypeOfPackage == null)
            return new TypeOfPackageResponse("Package not found.");
        try
        {
            _typeOfPackageRepository.Remove(existingTypeOfPackage);
            await _unitOfWork.CompleteAsync();

            return new TypeOfPackageResponse(existingTypeOfPackage);
        }
        catch (Exception e)
        {
            return new TypeOfPackageResponse($"An error occurred while deleting the package: {e.Message}");
        }

    }

}