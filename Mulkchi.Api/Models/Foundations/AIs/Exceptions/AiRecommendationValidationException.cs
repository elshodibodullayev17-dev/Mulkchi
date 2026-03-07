using Xeptions;

namespace Mulkchi.Api.Models.Foundations.AIs.Exceptions;

public class AiRecommendationValidationException : Xeptions.Xeption
{
    public AiRecommendationValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
