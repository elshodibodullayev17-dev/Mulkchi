using Xeptions;

namespace Mulkchi.Api.Models.Foundations.PropertyImages.Exceptions;

public class FailedPropertyImageStorageException : Xeptions.Xeption
{
    public FailedPropertyImageStorageException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
