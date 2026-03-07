using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class FailedPropertyServiceException : Xeptions.Xeption
{
    public FailedPropertyServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
