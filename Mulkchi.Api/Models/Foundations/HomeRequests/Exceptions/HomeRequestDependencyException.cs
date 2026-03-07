using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class HomeRequestDependencyException : Xeptions.Xeption
{
    public HomeRequestDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
