using Xeptions;

namespace Mulkchi.Api.Models.Foundations.AIs.Exceptions;

public class AiRecommendationDependencyValidationException : Xeptions.Xeption
{
    public AiRecommendationDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
