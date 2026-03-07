using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class ReviewServiceException : Xeptions.Xeption
{
    public ReviewServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
