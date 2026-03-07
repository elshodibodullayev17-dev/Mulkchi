using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class HomeRequestDependencyValidationException : Xeptions.Xeption
{
    public HomeRequestDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
