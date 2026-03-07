using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class UserValidationException : Xeptions.Xeption
{
    public UserValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
