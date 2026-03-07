using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class UserDependencyValidationException : Xeptions.Xeption
{
    public UserDependencyValidationException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
