using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class ReviewDependencyValidationException : Xeptions.Xeption
{
    public ReviewDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
