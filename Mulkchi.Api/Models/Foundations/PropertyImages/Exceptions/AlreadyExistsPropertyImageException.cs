using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class AlreadyExistsPropertyImageException : Xeptions.Xeption
{
    public AlreadyExistsPropertyImageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
