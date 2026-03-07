using Xeptions;

namespace Mulkchi.Api.Models.Foundations.AIs.Exceptions;

public class AiRecommendationDependencyException : Xeptions.Xeption
{
    public AiRecommendationDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
