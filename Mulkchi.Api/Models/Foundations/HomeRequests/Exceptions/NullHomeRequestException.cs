using Xeptions;

namespace Mulkchi.Api.Models.Foundations.HomeRequests.Exceptions;

public class NullHomeRequestException : Xeptions.Xeption
{
    public NullHomeRequestException(string message)
        : base(message)
    { }
}
