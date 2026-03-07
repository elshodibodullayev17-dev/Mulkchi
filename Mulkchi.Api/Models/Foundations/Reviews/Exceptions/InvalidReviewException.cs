using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class InvalidReviewException : Xeptions.Xeption
{
    public InvalidReviewException(string message)
        : base(message)
    { }

    public InvalidReviewException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
