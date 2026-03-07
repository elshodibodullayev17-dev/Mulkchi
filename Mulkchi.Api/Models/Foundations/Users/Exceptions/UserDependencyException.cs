using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class UserDependencyException : Xeptions.Xeption
{
    public UserDependencyException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
