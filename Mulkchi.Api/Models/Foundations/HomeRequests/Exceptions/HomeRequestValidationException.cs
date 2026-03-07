using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class HomeRequestValidationException : Xeptions.Xeption
{
    public HomeRequestValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
