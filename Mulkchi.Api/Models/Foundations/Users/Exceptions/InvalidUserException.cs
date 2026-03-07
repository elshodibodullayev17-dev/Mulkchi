using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class InvalidUserException : Xeptions.Xeption
{
    public InvalidUserException(string message)
        : base(message)
    { }

    public InvalidUserException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
