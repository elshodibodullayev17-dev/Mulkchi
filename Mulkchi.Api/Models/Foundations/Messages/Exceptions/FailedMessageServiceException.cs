using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class FailedMessageServiceException : Xeptions.Xeption
{
    public FailedMessageServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
