using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class MessageValidationException : Xeptions.Xeption
{
    public MessageValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
