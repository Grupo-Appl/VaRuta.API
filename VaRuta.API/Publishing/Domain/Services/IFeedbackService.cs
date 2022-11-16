using VaRuta.API.Publishing.Domain.Services.Communication;

namespace VaRuta.API.Publishing.Domain.Services;

public interface IFeedbackService
{
    Task<IEnumerable<Feedback>> ListAsync();
    Task<FeedbackResponse> SaveAsync(Feedback feedback);
    Task<FeedbackResponse> UpdateAsync(int id, Feedback feedback);
    Task<FeedbackResponse> DeleteAsync(int id);	
}