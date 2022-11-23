
using VaRuta.API.Shared.Domain.Services.Communication;

namespace VaRuta.API.Publishing.Domain.Services.Communication;

public class FeedbackResponse : BaseResponse<Feedback>
{
    public FeedbackResponse(string message) : base(message)
    {
    }

    public FeedbackResponse(Feedback resource) : base(resource)
    {
    }
}