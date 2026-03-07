using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class ReviewValidationException : Xeptions.Xeption
{
    public ReviewValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
