using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class FailedHomeRequestServiceException : Xeptions.Xeption
{
    public FailedHomeRequestServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
