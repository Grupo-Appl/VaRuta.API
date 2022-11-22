using VaRuta.API.Publishing.Domain;
using VaRuta.API.Publishing.Domain.Repositories;
using VaRuta.API.Publishing.Domain.Services;
using VaRuta.API.Publishing.Domain.Services.Communication;
using VaRuta.API.Shared.Domain.Repositories;

namespace VaRuta.API.Publishing.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository; 
    private readonly IUnitOfWork _unitOfWork;
    
    public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
    {
        _feedbackRepository = feedbackRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Feedback>> ListAsync()
    {
        return await _feedbackRepository.ListAsync();
    }
    
    public async Task<FeedbackResponse> SaveAsync(Feedback feedback)
    {
        try
        {
            await _feedbackRepository.AddAsync(feedback);
            await _unitOfWork.CompleteAsync();
            return new FeedbackResponse(feedback);
        }
        catch (Exception e)
        {
            return new FeedbackResponse($"An error occurred while saving the feedback: {e.Message}");
        }
    }
    
    public async Task<FeedbackResponse> UpdateAsync(int id, Feedback feedback)
    {
        var existingFeedback =await _feedbackRepository.FindByIdAsync(id);

        if (existingFeedback == null)
            return new FeedbackResponse("Feedback not found.");

        existingFeedback.Description = feedback.Description;
        existingFeedback.date = feedback.date;
        try
        {
            _feedbackRepository.Update(existingFeedback);
            await _unitOfWork.CompleteAsync();

            return new FeedbackResponse(existingFeedback);
        }
        catch (Exception e)
        {
            return new FeedbackResponse($"An error occurred while updating the feedback: {e.Message}");
        }
    }
    
    public async Task<FeedbackResponse> DeleteAsync(int id)
    {
        var existingFeedback = await _feedbackRepository.FindByIdAsync(id);

        if (existingFeedback == null)
            return new FeedbackResponse("feedback not found.");

        try
        {
            _feedbackRepository.Remove(existingFeedback);
            await _unitOfWork.CompleteAsync();

            return new FeedbackResponse(existingFeedback);

        }
        catch (Exception e)
        {
            return new FeedbackResponse($"An error occurred while deleting the feedback: {e.Message}");
        }
    }
    
    
    
    
}