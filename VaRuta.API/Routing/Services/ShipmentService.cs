using VaRuta.API.Routing.Domain.Models;
using VaRuta.API.Routing.Domain.Repositories;
using VaRuta.API.Routing.Domain.Services;
using VaRuta.API.Routing.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Routing.Services;

public class ShipmentService : IShipmentService
{
    private readonly IShipmentRepository _shipmentRepository; 
    private readonly IUnitOfWork _unitOfWork;

    public ShipmentService(IShipmentRepository shipmentRepository, IUnitOfWork unitOfWork)
    {
        _shipmentRepository = shipmentRepository;
        _unitOfWork = unitOfWork;
    }
        public async Task<IEnumerable<Shipment>> ListAsync()
        {
            return await _shipmentRepository.ListAsync();
        }

        public async Task<ShipmentResponse> SaveAsync(Shipment shipment)
        {
            try
            {
                await _shipmentRepository.AddAsync(shipment);
                await _unitOfWork.CompleteAsync();
                return new ShipmentResponse(shipment);
            }
            catch (Exception e)
            {
                return new ShipmentResponse($"An error occurred while saving the shipment: {e.Message}");
            }
        }

        public async Task<ShipmentResponse> UpdateAsync(int id, Shipment shipment)
        {
            var existingShipment = await _shipmentRepository.FindByIdAsync(id);

            if (existingShipment == null)
                return new ShipmentResponse("Shipment not found.");

            existingShipment.Description = shipment.Description;

            try
            {
                _shipmentRepository.Update(existingShipment);
                await _unitOfWork.CompleteAsync();

                return new ShipmentResponse(existingShipment);
            }
            catch (Exception e)
            {
                return new ShipmentResponse($"An error occurred while updating the shipment: {e.Message}");
            }
        }

        public async Task<ShipmentResponse> DeleteAsync(int id)
        {
            var existingShipment = await _shipmentRepository.FindByIdAsync(id);

            if (existingShipment == null)
                return new ShipmentResponse("Shipment not found.");

            try
            {
                _shipmentRepository.Remove(existingShipment);
                await _unitOfWork.CompleteAsync();

                return new ShipmentResponse(existingShipment);

            }
            catch (Exception e)
            {
                return new ShipmentResponse($"An error occurred while deleting the shipment: {e.Message}");
            }
        }

        
   
}