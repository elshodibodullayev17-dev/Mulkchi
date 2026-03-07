using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class NullUserException : Xeptions.Xeption
{
    public NullUserException(string message)
        : base(message)
    { }
}
