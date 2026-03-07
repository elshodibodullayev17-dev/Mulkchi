using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class MessageServiceException : Xeptions.Xeption
{
    public MessageServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
