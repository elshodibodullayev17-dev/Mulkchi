using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Messages.Exceptions;

public class AlreadyExistsMessageException : Xeptions.Xeption
{
    public AlreadyExistsMessageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
