using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class HomeRequestServiceException : Xeptions.Xeption
{
    public HomeRequestServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
