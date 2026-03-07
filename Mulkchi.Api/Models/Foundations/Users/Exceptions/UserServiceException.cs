using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class UserServiceException : Xeptions.Xeption
{
    public UserServiceException(string message, Xeptions.Xeption innerException)
        : base(message, innerException)
    { }
}
