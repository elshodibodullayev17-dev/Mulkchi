using Xeptions;

namespace Mulkchi.Api.Models.Foundations.AIs.Exceptions;

public class NotFoundAiRecommendationException : Xeptions.Xeption
{
    public NotFoundAiRecommendationException(Guid aiRecommendationId)
        : base(message: $"Could not find AI recommendation with id: {aiRecommendationId}")
    { }
}
