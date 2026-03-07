using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class MessageDependencyValidationException : Xeptions.Xeption
{
    public MessageDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
