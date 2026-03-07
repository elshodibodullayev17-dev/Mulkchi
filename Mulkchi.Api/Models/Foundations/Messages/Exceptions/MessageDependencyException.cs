using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class MessageDependencyException : Xeptions.Xeption
{
    public MessageDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
