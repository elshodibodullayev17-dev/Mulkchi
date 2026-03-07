using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Reviews.Exceptions;

public class ReviewDependencyException : Xeptions.Xeption
{
    public ReviewDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
