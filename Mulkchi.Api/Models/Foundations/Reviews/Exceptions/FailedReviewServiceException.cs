using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class FailedReviewServiceException : Xeptions.Xeption
{
    public FailedReviewServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
