using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Users.Exceptions;

public class FailedUserStorageException : Xeptions.Xeption
{
    public FailedUserStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
