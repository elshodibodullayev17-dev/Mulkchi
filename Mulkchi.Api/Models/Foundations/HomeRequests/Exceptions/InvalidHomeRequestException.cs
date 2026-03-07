using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class InvalidHomeRequestException : Xeptions.Xeption
{
    public InvalidHomeRequestException(string message)
        : base(message)
    { }

    public InvalidHomeRequestException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
