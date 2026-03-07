using Xeptions;

namespace Mulkchi.Api.Models.Foundations.Properties.Exceptions;

public class AlreadyExistsPropertyException : Xeptions.Xeption
{
    public AlreadyExistsPropertyException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
