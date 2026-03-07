using Xeptions;

namespace Mulkchi.Api.Models.Foundations.AIs.Exceptions;

public class AiRecommendationServiceException : Xeptions.Xeption
{
    public AiRecommendationServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
