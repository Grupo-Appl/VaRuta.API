using VaRuta.API.Shared.Domain.Repositories;
using VaRuta.API.Tracking.Domain.Models;
using VaRuta.API.Tracking.Domain.Repositories;
using VaRuta.API.Tracking.Domain.Services;
using VaRuta.API.Tracking.Domain.Services.Communication;

namespace VaRuta.API.Tracking.Services;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeliveryService(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
    {
        _deliveryRepository = deliveryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Delivery>> ListAsync()
    {
        return await _deliveryRepository.ListAsync();
    }

    public async Task<DeliveryResponse> SaveAsync(Delivery delivery)
    {
        try
        {
            await _deliveryRepository.AddAsync(delivery);
            await _unitOfWork.CompleteAsync();
            return new DeliveryResponse(delivery);
        }
        catch (Exception e)
        {
            return new DeliveryResponse($"An error occurred while saving delivery: {e.Message}");
        }
    }

    public async Task<DeliveryResponse> UpdateAsync(int id, Delivery delivery)
    {
        var existingDelivery = await _deliveryRepository.FindByIdAsync(id);

        if (existingDelivery == null)
            return new DeliveryResponse("Delivery not found.");

        existingDelivery.Description = delivery.Description;

        try
        {
            _deliveryRepository.Update(existingDelivery);
            await _unitOfWork.CompleteAsync();

            return new DeliveryResponse(existingDelivery);
        }
        catch (Exception e)
        {
            return new DeliveryResponse($"An error occurred while updating delivery: {e.Message}");
        }
    }

    public async Task<DeliveryResponse> DeleteAsync(int id)
    {
        var existingDelivery = await _deliveryRepository.FindByIdAsync(id);

        if (existingDelivery == null)
            return new DeliveryResponse("Delivery not found.");

        try
        {
            _deliveryRepository.Remove(existingDelivery);
            await _unitOfWork.CompleteAsync();

            return new DeliveryResponse(existingDelivery);
        }
        catch (Exception e)
        {
            return new DeliveryResponse($"An error occurred while deleting delivery: {e.Message}");
        }
    }
}